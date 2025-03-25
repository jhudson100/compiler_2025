namespace lab{

    public class OpMov: Opcode {
        long srcImmediate;
        IntRegister srcIntReg;
        FloatRegister srcFloatReg;

        IntRegister destIntReg;
        FloatRegister destFloatReg;

        public OpMov( long src, IntRegister dest){
            this.srcImmediate=src;
            this.srcIntReg=null;
            this.srcFloatReg=null;

            this.destIntReg=dest;
            this.destFloatReg=null;
        }

        public OpMov( FloatRegister src, IntRegister dest){
            this.srcImmediate=-1;
            this.srcIntReg=null;
            this.srcFloatReg=src;

            this.destIntReg=dest;
            this.destFloatReg=null;
        }

        public OpMov( ulong src, IntRegister dest) : this((long)src, dest){}

        public override void output(StreamWriter w){
            string src,dest;

            if( srcIntReg != null )
                src = srcIntReg.ToString();
            else if( srcFloatReg != null )
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