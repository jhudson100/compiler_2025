namespace lab{

    public class OpXchg: Opcode {
        IntRegister op1;
        IntRegister op2;

        public OpXchg( IntRegister op1, IntRegister op2){
            this.op1=op1;
            this.op2=op2;
        }

        public override bool touchesStack(){
            return false;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    xchg {this.op2}, {this.op1}");
        }
    }

}