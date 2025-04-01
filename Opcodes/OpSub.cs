namespace lab{

    public class OpSub: Opcode {
        IntRegister op1;
        IntRegister op2Reg=null;
        int op2Constant;

        // sub $42, %rax   <-- subtract constant from register
        public OpSub( IntRegister op1, int op2){
            this.op1=op1;
            this.op2Constant = op2;
        }

        //sub %rax, %rbx  <-- subtract register from register
        public OpSub( IntRegister op1, IntRegister op2){
            this.op1=op1;
            this.op2Reg = op2;
        }

        public override void output(StreamWriter w){
            if( this.op2Reg != null ){
                w.WriteLine($"    sub {this.op2Reg}, {this.op1}");
            } else {
                w.WriteLine($"    sub ${this.op2Constant}, {this.op1}");
            }
        }
    }

}