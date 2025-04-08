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


        //call rtinit to initialize the runtime
        w.WriteLine("    sub $32, %rsp");
        w.WriteLine("    call rtinit");
        w.WriteLine("    add $32, %rsp");

        //TBD: See if we have variable of the name of main
        //if not, make a nice message telling the user
        //we need a main function.

        VarInfo vi  = SymbolTable.lookup("main");
        if( vi.type as FunctionNodeType == null ){
            //error: main was declared but as a variable
        }
        GlobalLocation loc = vi.location as GlobalLocation;
        if( loc == null ){
            //error! print a nice message
        }
        w.WriteLine($"    call {loc.lbl.value}  /* {loc.lbl.comment} */");

        //return value from main is in rax

        w.WriteLine("    mov %rax, %r13");

        //call rtcleanup to cleanup our runtime
        w.WriteLine("    sub $32, %rsp");
        w.WriteLine("    call rtcleanup");
        w.WriteLine("    add $32, %rsp");

        w.WriteLine("    mov %r13, %rax");
        

        //call ExitProcess() with return value of main
        w.WriteLine("    mov %rax, %rcx");
        w.WriteLine("    sub $32,%rsp");
        w.WriteLine("    call ExitProcess");

        foreach( var op in ops ){
            op.output(w);
        }

        w.WriteLine(".section .data");
        foreach( string name in SymbolTable.table.Keys){
            vi = SymbolTable.table[name];
            loc = vi.location as GlobalLocation;
            if( vi.type as FunctionNodeType != null  )
                continue;
            w.WriteLine( $"{loc.lbl}:   /* {loc.lbl.comment} */" );
            w.WriteLine( "    .quad 0  /* storage class = primitive */");
            w.WriteLine( "    .quad 0  /* value */");
        }

    }
}

} //namespace
