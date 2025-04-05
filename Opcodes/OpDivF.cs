namespace lab{

    public class OpDivF: Opcode {
        FloatRegister op1;
        FloatRegister op2;
        public OpDivF( FloatRegister n, FloatRegister d){
            this.op1=n;
            this.op2=d;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"     divsd {op2}, {op1}");
        }
    }

}