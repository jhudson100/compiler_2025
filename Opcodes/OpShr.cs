namespace lab{

    public class OpShr: Opcode {
        IntRegister value;
        IntRegister count;
        public OpShr( IntRegister value, IntRegister count){
            this.value=value;
            this.count=count;
            if( this.count != Register.rcx ){
                throw new Exception("must be rcx");  //x86 weirdness
            }
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    shr %cl, {this.value}");
        }
    }

}