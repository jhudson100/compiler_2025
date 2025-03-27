namespace lab{

    public class OpMov: Opcode {
        long srcImmediate;
        IntRegister srcIntReg=null;
        FloatRegister srcFloatReg=null;

        IntRegister destIntReg=null;
        FloatRegister destFloatReg=null;

        public OpMov( long src, IntRegister dest){
            this.srcImmediate=src;
            this.destIntReg=dest;
        }

        public OpMov( IntRegister src, int offset, IntRegister dest){
            this.srcImmediate = offset;
            this.srcIntReg = src;
            this.destIntReg = dest;
        }

        public OpMov( FloatRegister src, IntRegister dest){
            this.srcImmediate=-1;
            this.srcFloatReg=src;
            this.destIntReg=dest;
        }

        public OpMov( ulong src, IntRegister dest) : this((long)src, dest){}

        public override void output(StreamWriter w){
            string src,dest;

            if( srcIntReg != null ){
                if( srcImmediate == 0 )
                    src = srcIntReg.ToString();     //src = "%rax"
                else {
                    src = $" {srcImmediate}({srcIntReg})";  //src = "8(%rsp)
                }
            }else if( srcFloatReg != null )
                src = srcFloatReg.ToString();
            else
                src = $"{srcImmediate}";

            if( destIntReg != null )
                dest = destIntReg.ToString();
            else 
                dest = destFloatReg.ToString();

            w.WriteLine($"    movq ${src}, {dest}");
        }
    }


}