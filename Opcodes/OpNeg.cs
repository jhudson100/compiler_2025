namespace lab{

    public class OpNeg: Opcode {
        IntRegister reg;
        public OpNeg( IntRegister reg){
            this.reg=reg;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    neg {reg}");
        }
    }

}