namespace lab{

    public class OpAdd: Opcode {
        IntRegister op1;
        int op2Constant;

        public OpAdd( IntRegister op1, int op2){
            this.op1=op1;
            this.op2Constant = op2;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    add ${this.op2Constant}, {this.op1}");
        }
    }

}