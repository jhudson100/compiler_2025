namespace Configuration{

    public static class Configuration {

/*
        //Example paths for Windows


        //Command to execute clang
        public static readonly string[] clang = new string[] {
            @"c:\program files\llvm\bin\clang.exe","-g","-c","{}"
        };

        //Commands that need to be executed before compiling asm code
        public static readonly string[][] prerequisites = new string[][]{
            new string[]{@"c:\program files\llvm\bin\llvm-dlltool.exe",
                          "-m", "i386:x86-64",
                          "-d", "kernel32.def",
                          "-l", "kernel32.lib"
            },
            new string[]{@"c:\program files\llvm\bin\clang.exe","-g","-c","runtime.c"}
        };

        //Command to link everything together
        public static readonly string[] linker = new string[]{
            @"c:\program files\llvm\bin\lld-link.exe", "/debug",
            "/entry:_start", "/subsystem:console", "/out:out.exe", "{}", "kernel32.lib", "runtime.o"
        };
*/

        //Example paths for Linux

        //Command to execute clang
        public static readonly string[] clang = new string[] {
            "clang","-g","-c","{}"
        };

        //Commands that need to be executed before compiling asm code
        public static readonly string[][] prerequisites = new string[][]{
            ["clang", "-g", "-c", "ExitProcess.c"],
            ["clang", "-g", "-c", "ReadFile.c"],
            ["clang", "-g", "-c", "WriteFile.c"],
            ["clang", "-g", "-c", "GetStdHandle.c"],
            ["clang", "-g", "-c", "CloseHandle.c"],
            ["clang", "-g", "-c", "runtime.c"]
        };

        //Command to link everything together
        public static readonly string[] linker = new string[]{
            "ld.lld", "-o", "out.exe", "{}", "ExitProcess.o",
                "ReadFile.o","WriteFile.o","GetStdHandle.o",
                "CloseHandle.o","runtime.o"
        };

        public static string readonlyDataSection = ".rodata";
    }

}
