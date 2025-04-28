namespace lab{

    public class OpMov: Opcode {
        long srcImmediate;              //mov $42, ....


        IntRegister srcIntReg=null;     //mov %rax, ...
        FloatRegister srcFloatReg=null; //mov %xmm0, ...
        //are we moving from memory?
        bool srcIndirect=false;
        int srcOffset;
        Label srcLabel=null;

        IntRegister destIntReg=null;
        FloatRegister destFloatReg=null;
        bool destIndirect=false;
        int destOffset;

        string comment = "";

        //move immediate (constant) to an int register
        public OpMov( long src, IntRegister dest, string comment){
            this.srcImmediate=src;
            this.destIntReg=dest;
            this.comment=comment;
        }


        //move label to an int register
        public OpMov( Label src, IntRegister dest){
            this.srcLabel=src;
            this.destIntReg=dest;
        }

        //copy an int register to another int register
        public OpMov( IntRegister src, IntRegister dest){
            this.srcIntReg = src;
            this.destIntReg = dest;
        }

        public OpMov( IntRegister src, int offset, IntRegister dest, string comment=""){
            this.srcIntReg = src;
            this.destIntReg = dest;
            this.srcOffset = offset;
            this.srcIndirect=true;
            this.comment=comment;
        }



        public OpMov( IntRegister src, IntRegister dest, int offset, string comment){
            this.srcIntReg = src;
            this.destIntReg = dest;
            this.destOffset = offset;
            this.destIndirect=true;
            this.comment=comment;
        }


        public OpMov( Label src, IntRegister dest, int offset, string comment){
            this.srcLabel = src;
            this.destIntReg = dest;
            this.destOffset = offset;
            this.destIndirect=true;
            this.comment=comment;
        }


        public OpMov( int src, IntRegister dest, int offset, string comment){
            this.srcImmediate = src;
            this.destIntReg = dest;
            this.destOffset = offset;
            this.destIndirect=true;
            this.comment=comment;
        }

        //mov float register to an int register
        public OpMov( FloatRegister src, IntRegister dest){
            this.srcFloatReg=src;
            this.destIntReg=dest;
        }

        //mov constant to register
        public OpMov( ulong src, IntRegister dest) : this((long)src, dest,""){}

        public override void output(StreamWriter w){
            string opcode = "movq";

            string src,dest;
            string comment = this.comment;
            if( srcIndirect ){
                src = $"{srcOffset}({srcIntReg})";
            } else {
                if( srcIntReg != null ){
                    src = srcIntReg.ToString();     //src = "%rax"
                } else if( srcFloatReg != null ) {
                    src = srcFloatReg.ToString();
                } else if( srcLabel != null ) {
                    opcode = "movabs";
                    src = "$"+srcLabel.value;   //want the address the label is pointing to
                    comment += " "+srcLabel.comment;
                }
                else{
                    src = $"${srcImmediate}";
                }
            }

            if( destIndirect ){
                // 8(%rcx)
                dest = $"{destOffset}({destIntReg})";
            } else {
                if( destIntReg != null )
                    dest = destIntReg.ToString();
                else 
                    dest = destFloatReg.ToString();
            }

            w.WriteLine($"    {opcode} {src}, {dest}    /* {comment} */");
        }
    }


}