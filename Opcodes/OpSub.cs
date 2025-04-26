namespace lab{

    public class OpSub: Opcode {
        IntRegister op1;
        IntRegister op2Reg=null;
        int op2Constant;
        string comment="";

        // sub $42, %rax   <-- subtract constant from register
        public OpSub( IntRegister op1, int op2, string comment=""){
            this.op1=op1;
            this.op2Constant = op2;
            this.comment=comment;
        }

        //sub %rax, %rbx  <-- subtract register from register
        public OpSub( IntRegister op1, IntRegister op2){
            this.op1=op1;
            this.op2Reg = op2;
        }

        public override bool touchesStack(){
           return this.op1 == Register.rsp;
        }

        public override void output(StreamWriter w){
            string comment = this.comment;
            if( comment.Length > 0 )
                comment = "/* " + comment + " */";

            if( this.op2Reg != null ){
                w.WriteLine($"    sub {this.op2Reg}, {this.op1}  {comment}");
            } else {
                w.WriteLine($"    sub ${this.op2Constant}, {this.op1}  {comment}");
            }
        }
    }

}