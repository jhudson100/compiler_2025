namespace lab{

    public class OpCall: Opcode {
        IntRegister op1;
        string comment;

        public OpCall( IntRegister op1, string comment){
            this.op1=op1;
            this.comment = comment;
        }

        public override void output(StreamWriter w){
            string comment = this.comment;
            if( comment.Length > 0 )
                comment = "/* "+comment+" */";
            w.WriteLine($"    call *{op1}   {comment}");
        }
    }

}