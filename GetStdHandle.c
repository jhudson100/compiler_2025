

typedef unsigned long long uint64_t;
typedef signed long long int64_t;
typedef int                     BOOL;
typedef unsigned                DWORD; //32 bits
typedef void*                   HANDLE;
#define TRUE 1
#define FALSE 0
#define INVALID_HANDLE_VALUE    ( (HANDLE)( (int64_t)-1 ))

_Static_assert( sizeof(DWORD)       == 4, "DWORD bad");
_Static_assert( sizeof(int64_t)     == 8, "int64_t bad");
_Static_assert( sizeof(uint64_t)    == 8, "uint64_t bad");
_Static_assert( sizeof(HANDLE)      == 8, "HANDLE bad");

__attribute__((ms_abi))
HANDLE GetStdHandle(DWORD h){
    switch(h){
        case 0xfffffff6: return (HANDLE)0;  //stdin
        case 0xfffffff5: return (HANDLE)1;  //stdout
        case 0xfffffff4: return (HANDLE)2;  //stderr
        default: return  INVALID_HANDLE_VALUE;
    }
}
