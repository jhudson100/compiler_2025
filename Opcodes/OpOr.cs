namespace lab{

    public class OpOr: Opcode {
        IntRegister op1;
        IntRegister op2;

        public OpOr( IntRegister op1, IntRegister op2){
            this.op1=op1;
            this.op2 = op2;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    or {this.op2}, {this.op1}");
        }
    }

}