typedef void*                   HANDLE;
typedef unsigned                DWORD; //32 bits
typedef signed long long        int64_t;
_Static_assert( sizeof(DWORD)       == 4, "DWORD bad");
_Static_assert( sizeof(int64_t)     == 8, "int64_t bad");
#define NULL ((void*)0)


typedef struct StackVar_ {
    int64_t storageClass;
    int64_t value;
} StackVar;

typedef struct String_ {
    int64_t length;
    char data[1];       //bogus length
} String;

HANDLE stdin;
HANDLE stdout;

//runtime init
__attribute__((ms_abi)) void rtinit(){
    stdin = GetStdHandle(0xfffffff6);
    stdout = GetStdHandle(0xfffffff5);
}

__attribute__((ms_abi)) int putc(StackVar stk[])
{
    DWORD count;
    char v = stk[0].value;
    int rv = WriteFile( stdout, &v, 1, &count, NULL );
    if(rv == 0 || count == 0 )
        return 0;
    else
        return 1;
}

//runtime cleanup
__attribute__((ms_abi)) void rtcleanup()
{
    CloseHandle(stdin);
    CloseHandle(stdout);
}



__attribute__((ms_abi)) void print(StackVar stk[])
{
    String* s = (String*) stk[0].value;
    DWORD count;
    char* p = s->data;
    int64_t numLeft = s->length;
    while( numLeft ){
        WriteFile( stdout, p, numLeft, &count, NULL );
        numLeft -= count;
        p += count;
    }
}