namespace lab{


public static class Asm{
    public static List<Opcode> ops = new();

    public static void add(Opcode op){
        ops.Add(op);
    }

    public static void output(StreamWriter w){
        //asm prologue
        w.WriteLine(".section .text");
        w.WriteLine(".global _start");
        w.WriteLine("_start:");
        w.WriteLine("    andq $~0xf, %rsp  /*align the stack*/");

        //TBD: See if we have variable of the name of main
        //if not, make a nice message telling the user
        //we need a main function.

        if( !SymbolTable.table.ContainsKey("main")){
            Console.Error.WriteLine("WARNING: File does not have a main() method; executable will not be valid");
        } else {
            VarInfo vi  = SymbolTable.lookup("main");
            if( vi.type as FunctionNodeType == null ){
                //error: main was declared but as a variable
                throw new Exception();
            }
            GlobalLocation loc = vi.location as GlobalLocation;
            if( loc == null ){
                //error! print a nice message
                throw new Exception();
            }
            w.WriteLine($"    call {loc.lbl.value}  /* {loc.lbl.comment} */");
        }

        //return value from main is in rax

        //call ExitProcess() with return value of main
        w.WriteLine("    mov %rax, %rcx");
        w.WriteLine("    sub $32,%rsp");
        w.WriteLine("    call ExitProcess");

        foreach( var op in ops ){
            op.output(w);
        }

        w.WriteLine(".section .data");
        foreach( string name in SymbolTable.table.Keys){
            var vi = SymbolTable.table[name];
            var loc = vi.location as GlobalLocation;
            if( vi.type as FunctionNodeType != null  )
                continue;
            w.WriteLine( $"{loc.lbl}:   /* {loc.lbl.comment} */" );
            w.WriteLine( "    .quad 0  /* storage class = primitive */");
            w.WriteLine( "    .quad 0  /* value */");
        }

    }
}

} //namespace
