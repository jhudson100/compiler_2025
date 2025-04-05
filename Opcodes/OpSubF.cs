namespace lab{

    public class OpSubF: Opcode {
        FloatRegister op1;
        FloatRegister op2;
        public OpSubF( FloatRegister n, FloatRegister d){
            this.op1=n;
            this.op2=d;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"     subsd {op2}, {op1}");
        }
    }

}