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
        w.WriteLine("    sub $8,%rsp"); //need to keep stack aligned
        w.WriteLine("    push %rax");
        w.WriteLine("    sub $32, %rsp");
        w.WriteLine("    call rtcleanup");
        w.WriteLine("    add $32, %rsp");
        w.WriteLine("    pop %rcx");    //return value goes to rcx so it's parameter to ExitProcess
        w.WriteLine("    sub $24,%rsp");    //already have sub 8 above
        w.WriteLine("    call ExitProcess");

        foreach( var op in ops ){
            op.output(w);
        }

        w.WriteLine(".section "+Configuration.Configuration.readonlyDataSection);

        w.WriteLine("emptyString:");
        w.WriteLine(".quad 0");

        foreach(var t in StringPool.allStrings ){
            w.WriteLine($"{t.Value.value}:  /* {t.Value.comment} */" );
            w.WriteLine("    .quad "+t.Key.Length);
            w.Write("    .byte ");
            string sep="";
            foreach(char c in t.Key){
                w.Write(sep);
                w.Write( (int)c);
                sep=", ";
            }
            //padding
            for(int i=0;i<8 - t.Key.Length % 8; ++i){
                w.Write(", 0");
            }
            w.WriteLine();
        }
        
        w.WriteLine(".section .data");
        foreach( string name in SymbolTable.table.Keys){
            vi = SymbolTable.table[name];
            loc = vi.location as GlobalLocation;
            if( vi.type as FunctionNodeType != null  )
                continue;
            w.WriteLine( $"{loc.lbl}:   /* {loc.lbl.comment} */" );
            if( vi.type == NodeType.String){
                w.WriteLine("    .quad 0  /* storage class = primitive */");
                w.WriteLine("    .quad emptyString");
            } else {
                w.WriteLine( "    .quad 0  /* storage class = primitive */");
                w.WriteLine( "    .quad 0  /* value */");
            }
        }

    }
}

} //namespace
