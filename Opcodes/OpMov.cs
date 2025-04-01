namespace lab{

    public class OpMov: Opcode {
        long immediate;              //mov $42, ....


        IntRegister srcIntReg=null;     //mov %rax, ...
        FloatRegister srcFloatReg=null; //mov %xmm0, ...
        //are we moving from memory?
        bool srcIndirect=false;
        Label srcLabel=null;

        IntRegister destIntReg=null;
        FloatRegister destFloatReg=null;
        bool destIndirect=false;

        //move immediate (constant) to an int register
        public OpMov( long src, IntRegister dest){
            this.immediate=src;
            this.destIntReg=dest;
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

        public OpMov( IntRegister src, int offset, IntRegister dest){
            this.srcIntReg = src;
            this.destIntReg = dest;
            this.immediate = offset;
            this.srcIndirect=true;
        }



        public OpMov( IntRegister src, IntRegister dest, int offset){
            this.srcIntReg = src;
            this.destIntReg = dest;
            this.immediate = offset;
            this.destIndirect=true;
        }
        //mov float register to an int register
        public OpMov( FloatRegister src, IntRegister dest){
            this.immediate=-1;
            this.srcFloatReg=src;
            this.destIntReg=dest;
        }

        //mov constant to register
        public OpMov( ulong src, IntRegister dest) : this((long)src, dest){}

        public override void output(StreamWriter w){
            string src,dest;
            string comment = "";
            if( srcIndirect ){
                src = $"{immediate}({srcIntReg})";
            } else {
                if( srcIntReg != null ){
                    src = srcIntReg.ToString();     //src = "%rax"
                } else if( srcFloatReg != null ) {
                    src = srcFloatReg.ToString();
                } else if( srcLabel != null ) {
                    src = "$"+srcLabel.value;   //want the address the label is pointing to
                    comment = srcLabel.comment;
                }
                else
                    src = $"${immediate}";
            }

            if( destIndirect ){
                // 8(%rcx)
                dest = $"{immediate}({destIntReg})";
            } else {
                if( destIntReg != null )
                    dest = destIntReg.ToString();
                else 
                    dest = destFloatReg.ToString();
            }

            w.WriteLine($"    movq {src}, {dest}    /* {comment} */");
        }
    }


}