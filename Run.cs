using System.Diagnostics;
using Configuration;

namespace lab{

    public static class Run {


        //Set this to true to print more information to the screen
        static bool verbose=false;

        public static void run(string[] args){
            run(new List<string>(args));
        }
        public static void run(List<string> args){
            var p = new Process();

            if(verbose)
                Console.Write(args[0]);

            var si = new ProcessStartInfo(args[0]);
            for(int i=1;i<args.Count;++i){
                si.ArgumentList.Add(args[i]);

                if(verbose)
                    Console.Write(" "+args[i]);
            }

            if(verbose)
                Console.WriteLine();

            si.CreateNoWindow=true;
            si.RedirectStandardError=true;
            si.RedirectStandardOutput=true;
            si.UseShellExecute=false;
            si.WorkingDirectory = Environment.CurrentDirectory;
            p.StartInfo = si;
            p.OutputDataReceived += new DataReceivedEventHandler(
                (sender,ev) => {
                    if(ev.Data != null)
                        Console.WriteLine(ev.Data);
                }
            );
            p.ErrorDataReceived += new DataReceivedEventHandler(
                (sender,ev) => {
                    if(ev.Data != null )
                        Console.WriteLine(ev.Data);
                }
            );

            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();

            if( p.ExitCode != 0 ){
                Console.WriteLine($"Process {args[0]} exited with code {p.ExitCode}");
                Environment.Exit(1);
            }
        }

        public static void replace(List<string> lst, params string[] values){
            for(int i=0;i<lst.Count;++i){
                if(lst[i] == "{}" ){
                    lst.RemoveAt(i);
                    lst.InsertRange(i,values);
                    return;
                }
            }
            throw new Exception();
        }

        public static void compile(params string[] inputs){

            //run each prerequisite command
            foreach(string[] cmd in Configuration.Configuration.prerequisites){
                run(cmd);
            }

            //build all inputs
            List<string> objs = new();

            foreach(var inp in inputs){
                var clang = new List<string>(Configuration.Configuration.clang);
                replace(clang,inp);
                run(clang);
                int idx = inp.LastIndexOf('.');
                if( idx == -1 )
                    throw new Exception();
                objs.Add( inp.Substring(0,idx) + ".o" );
            }

            //link everything together
            var link = new List<string>(Configuration.Configuration.linker);
            replace(link,objs.ToArray());
            run(link);
        }
    }

}
