namespace lab{

    public class OpNot: Opcode {
        IntRegister value;
        public OpNot( IntRegister value){
            this.value=value;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    not {this.value}");
        }
    }

}