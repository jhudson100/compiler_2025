namespace lab{

    public class OpCmpF: Opcode {
        string cc;
        FloatRegister op1,op2;
        public OpCmpF(string cc, FloatRegister op1, FloatRegister op2){
            this.cc=cc;
            this.op1=op1;
            this.op2=op2;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    cmp{cc}sd {op2}, {op1}");
        }
    }

}