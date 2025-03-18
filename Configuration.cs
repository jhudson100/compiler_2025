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
            }
        };

        //Command to link everything together
        public static readonly string[] linker = new string[]{
            @"c:\program files\llvm\bin\lld-link.exe", "/debug",
            "/entry:_start", "/subsystem:console", "/out:out.exe", "{}", "kernel32.lib"
        };
*/

        //Example paths for Linux

        //Command to execute clang
        public static readonly string[] clang = new string[] {
            "clang","-g","-c","{}"
        };

        //Commands that need to be executed before compiling asm code
        public static readonly string[][] prerequisites = new string[][]{
            new string[]{"clang", "-g", "-c", "ExitProcess.c"}
        };

        //Command to link everything together
        public static readonly string[] linker = new string[]{
            "ld.lld", "-o", "out.exe", "{}", "ExitProcess.o"
        };

    }

}
