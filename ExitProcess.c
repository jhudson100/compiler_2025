

//Linux system call numbers:
//  https://chromium.googlesource.com/chromiumos/docs/+/master/constants/syscalls.md
//  https://filippo.io/linux-syscall-table/
//  https://blog.rchapman.org/posts/Linux_System_Call_Table_for_x86_64/
#define SYSCALL_EXIT 60

typedef unsigned long long uint64_t;
typedef signed long long int64_t;

static int64_t doSyscall1(uint64_t syscallNumber, uint64_t p0)
{
    asm("syscall"
        :   "+a"(syscallNumber),
            "+D"(p0)
        :
        : "rbx","rcx","rdx","rsi","r8","r9","r10","r11","r12","r13","r14","r15","flags","memory"
    );
    return (int64_t)syscallNumber;
}

__attribute__((ms_abi)) void ExitProcess(unsigned status)
{
    //60=exit
    doSyscall1(SYSCALL_EXIT, status);
}
