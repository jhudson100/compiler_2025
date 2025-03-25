namespace lab{

    public class OpXor: Opcode {
        IntRegister value1;
        IntRegister value2;
        public OpXor( IntRegister value1, IntRegister value2){
            this.value1=value1;
            this.value2=value2;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    xor {this.value2}, {this.value1}");
        }
    }

}