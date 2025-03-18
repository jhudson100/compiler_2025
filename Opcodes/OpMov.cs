namespace lab{

    public class OpMov: Opcode {
        long src;
        IntRegister dest;
        public OpMov( long src, IntRegister dest){
            this.src=src;
            this.dest=dest;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    movq ${this.src}, {this.dest}");
        }
    }


}