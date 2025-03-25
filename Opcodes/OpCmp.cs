namespace lab{

    public class OpCmp: Opcode {
        IntRegister value1;
        IntRegister value2;
        public OpCmp( IntRegister value1, IntRegister value2){
            this.value1=value1;
            this.value2=value2;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    cmp {this.value2}, {this.value1}");
        }
    }

}