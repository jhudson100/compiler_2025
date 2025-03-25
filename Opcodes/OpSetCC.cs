namespace lab{

    public class OpSetCC: Opcode {
        string cc;
        IntRegister value1;
        public OpSetCC(string cc, IntRegister value1){
            this.cc=cc;
            this.value1=value1;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    set{cc} {this.value1.lowbyte}");
            w.WriteLine($"    movzx {this.value1.lowbyte}, {this.value1}");
        }
    }

}