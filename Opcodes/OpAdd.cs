namespace lab{

    public class OpAdd: Opcode {
        IntRegister op1;
        int op2Constant;
        IntRegister op2=null;

        public OpAdd( IntRegister op1, int op2){
            this.op1=op1;
            this.op2Constant = op2;
        }
        public OpAdd( IntRegister op1, IntRegister op2){
            this.op1=op1;
            this.op2 = op2;
        }

        public override void output(StreamWriter w){
            if( op2 == null )
                w.WriteLine($"    add ${this.op2Constant}, {this.op1}");
            else
                w.WriteLine($"    add {this.op2}, {this.op1}");
        }
    }

}