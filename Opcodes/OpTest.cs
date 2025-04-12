namespace lab{

    public class OpTest: Opcode {
        IntRegister op1;

        public OpTest( IntRegister op1){
            this.op1=op1;
        }
        public override void output(StreamWriter w){
            w.WriteLine($"    test {this.op1}, {this.op1}");
        }
    }

}