namespace lab{

    public class OpDiv: Opcode {
        IntRegister numerator;
        IntRegister denominator;
        public OpDiv( IntRegister n, IntRegister d){
            this.numerator=n;
            this.denominator=d;
            if( this.numerator != Register.rax ){
                throw new Exception();  //x86 weirdness
            }
        }

        public override void output(StreamWriter w){
            w.WriteLine("     cqo");
            w.WriteLine($"    idiv {this.denominator}");
        }
    }

}