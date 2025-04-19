
typedef unsigned long long uint64_t;
typedef signed long long int64_t;
typedef int                     BOOL;
typedef unsigned                DWORD; //32 bits
typedef void*                   HANDLE;
#define TRUE 1
#define FALSE 0

_Static_assert( sizeof(DWORD)       == 4, "DWORD bad");
_Static_assert( sizeof(int64_t)     == 8, "int64_t bad");
_Static_assert( sizeof(uint64_t)    == 8, "uint64_t bad");
_Static_assert( sizeof(HANDLE)      == 8, "HANDLE bad");

static int64_t doSyscall6(uint64_t syscallNumber, uint64_t p0, uint64_t p1, uint64_t p2, uint64_t p3, uint64_t p4, uint64_t p5)
{
    register uint64_t r10 asm ("r10") = p3;
    register uint64_t r8 asm ("r8") = p4;
    register uint64_t r9 asm ("r9") = p5;

    //Some discussion on whether syscall does indeed preserve
    //registers. To be safe, mark all as clobbered.
    //ref: https://lore.kernel.org/lkml/20211012230204.587193-1-ammar.faizi@students.amikom.ac.id/t/
    asm("syscall"
        :   "+a"(syscallNumber),
            "+D"(p0),
            "+S"(p1),
            "+d"(p2),
            "+r"(r10),
            "+r"(r8),
            "+r"(r9)
        :
        : "rbx","rcx","r11","r12","r13","r14","r15","flags","memory"
    );
    return (int64_t)syscallNumber;
}


static int64_t doSyscall3(uint64_t syscallNumber, uint64_t p0, uint64_t p1, uint64_t p2){
    return doSyscall6(syscallNumber,p0,p1,p2,0,0,0);
}

__attribute__((ms_abi)) BOOL WriteFile(
    HANDLE      H,
    char*       buff,
    DWORD       size,
    DWORD*      count,
    void*       overlapped
){
    if(count)
        *count=0;

    //1=write()
    int64_t rv = doSyscall3( 1, (uint64_t)H, (uint64_t)buff, (uint64_t) size );
    if( rv < 0 ){
        return FALSE;
    }
    if(count)
        *count=(DWORD) rv;
    return TRUE;
}
