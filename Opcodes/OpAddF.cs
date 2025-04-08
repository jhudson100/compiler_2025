namespace lab{

    public class OpAddF: Opcode {
        FloatRegister op1;
        FloatRegister op2;
        public OpAddF( FloatRegister n, FloatRegister d){
            this.op1=n;
            this.op2=d;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"     addsd {op2}, {op1}");
        }
    }

}