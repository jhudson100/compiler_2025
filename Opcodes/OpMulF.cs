namespace lab{

    public class OpMulF: Opcode {
        FloatRegister op1;
        FloatRegister op2;
        public OpMulF( FloatRegister n, FloatRegister d){
            this.op1=n;
            this.op2=d;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"     mulsd {op2}, {op1}");
        }
    }

}