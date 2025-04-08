namespace lab{

    public class OpAnd: Opcode {
        IntRegister op1;
        IntRegister op2=null;
        int constant;

        public OpAnd( IntRegister op1, IntRegister op2){
            this.op1=op1;
            this.op2 = op2;
        }

        public OpAnd( IntRegister op1, int constant){
            this.op1=op1;
            this.constant = constant;
        }

        public override void output(StreamWriter w){
            if( this.op2 != null )
                w.WriteLine($"    and {this.op2}, {this.op1}");
            else
                w.WriteLine($"    and $1, {this.op1}");
        }
    }

}