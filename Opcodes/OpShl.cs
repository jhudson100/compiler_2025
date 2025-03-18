namespace lab{

    public class OpShl: Opcode {
        IntRegister value;
        IntRegister count;
        public OpShl( IntRegister value, IntRegister count){
            this.value=value;
            this.count=count;
            if( this.count != Register.rcx ){
                throw new Exception();  //x86 weirdness
            }
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    shl %cl, {this.value}");
        }
    }

}