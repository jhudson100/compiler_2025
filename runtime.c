typedef void*                   HANDLE;
typedef unsigned                DWORD; //32 bits
typedef int                     BOOL;
typedef signed long long        int64_t;
typedef unsigned long long        uint64_t;
_Static_assert( sizeof(DWORD)       == 4, "DWORD bad");
_Static_assert( sizeof(int64_t)     == 8, "int64_t bad");
#define NULL 0

typedef struct StackVar_ {
    int64_t storageClass;
    int64_t value;
} StackVar;

static HANDLE stdin;
static HANDLE stdout;
static HANDLE stderr;


__attribute__((ms_abi))
HANDLE GetStdHandle(DWORD h);

__attribute__((ms_abi))
BOOL CloseHandle(HANDLE H);

__attribute__((ms_abi)) BOOL WriteFile(
    HANDLE      H,
    char*       buff,
    DWORD       size,
    DWORD*      count,
    void*       overlapped
);

__attribute__((ms_abi)) BOOL ReadFile(
    HANDLE      H,
    char*       buff,
    DWORD       size,
    DWORD*      count,
    void*       overlapped
);

//runtime init
__attribute__((ms_abi)) void rtinit()
{
    stdin = GetStdHandle(0xfffffff6);
    stdout = GetStdHandle(0xfffffff5);
    stderr = GetStdHandle(0xfffffff4);
}


//runtime cleanup
__attribute__((ms_abi)) void rtcleanup()
{
    CloseHandle(stdin);
    CloseHandle(stdout);
    CloseHandle(stderr);
}


__attribute__((ms_abi)) void putc(StackVar* stk)
{
    DWORD count;
    char v = stk[0].value;
    WriteFile( stdout, &v, 1, &count, NULL );
}

__attribute__((ms_abi)) void newline(StackVar* stk)
{
    DWORD count;
    char v = '\n';
    WriteFile( stdout, &v, 1, &count, NULL );
}


unsigned toHex(uint64_t x, char output[16]){
    unsigned shiftcount = 60;
    unsigned oo=0;
    const char* digits = "0123456789abcdef";
    if( x == 0 ){
        output[0]='0';
        return 1;
    }
    for(unsigned i=0;i<16;++i){
        unsigned j = (unsigned)((x>>shiftcount) & 0xf );
        if( oo > 0 || j )
            output[oo++] = digits[j];
        shiftcount -= 4;
    }
    return oo;
}

unsigned toDecimal(uint64_t x, char output[20])
{
    if( x == 0 ){
        *output = '0';
        return 1;
    }
    //2**64        = 18446744073709551616
    uint64_t place = 10000000000000000000ULL;
    int oo=0;
    while(place > 0 ){
        int64_t quotient = x/place;
        if( quotient || oo > 0 ) {
            output[oo++] = '0' + quotient;
        }
        x = x - quotient * place;
        place = place/10;
    }
    return oo;
}

unsigned toBin(uint64_t number, char output[64]){
    uint64_t mask = 0x8000000000000000ULL;
    if( number == 0 ){
        output[0]=0;
        return 1;
    }
    int oo=0;
    for(int i=0;i<64;++i,mask>>=1){
        if( mask & number ){
            output[oo++] = '1';
        } else {
            if( oo > 0 )
                output[oo++] = '0';
        }
    }
    return oo;
}
        

__attribute__((ms_abi)) unsigned putv(StackVar* stk)
{
    uint64_t value = stk[0].value;
    uint64_t base = stk[1].value;
    char A[32];
    unsigned count;
    switch(base){
        case 2:
            count = toBin(value,A);
            break;
        case 10:
            count = toDecimal(value,A);
            break;
        case 16:
            count = toHex(value,A);
            break;
        default:
            return 0;
    }
    unsigned nw;
    while(count > 0){
        if( 0 == WriteFile( stdout, A, count, &nw, NULL ) ){
            return 0;
        } 
        count -= nw;
    }
    return 1;
}


__attribute__((ms_abi)) unsigned getc(StackVar* stk)
{
    char A[1];
    DWORD count=1;
    if( 0 == ReadFile( stdin, A, 1, &count, NULL ) )
        return -1;   //error; what to return?
    return A[0];
}
