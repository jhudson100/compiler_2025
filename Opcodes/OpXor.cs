namespace lab{

    public class OpXor: Opcode {
        IntRegister value1;
        IntRegister value2;
        int constant;

        public OpXor( IntRegister value1, IntRegister value2){
            this.value1=value1;
            this.value2=value2;
        }
        public OpXor( IntRegister value1, int constant){
            this.value1=value1;
            this.value2=null;
            this.constant=constant;
        }

        public override void output(StreamWriter w){
            if(this.value2 != null )
                w.WriteLine($"    xor {this.value2}, {this.value1}");
            else
                w.WriteLine($"    xor ${this.constant}, {this.value1}");
        }
    }

}