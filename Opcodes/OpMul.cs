namespace lab{

    public class OpMul: Opcode {
        IntRegister multiplier;
        IntRegister multiplicand;
        public OpMul( IntRegister m1, IntRegister m2){
            this.multiplier=m1;
            this.multiplicand=m2;
            if( this.multiplier != Register.rax ){
                throw new Exception();  //x86 weirdness
            }
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    imul {this.multiplicand}");
        }
    }

}