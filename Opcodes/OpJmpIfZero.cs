namespace lab{

    public class OpJmpIfZero: Opcode {
        IntRegister value1;
        Label lbl;
        public OpJmpIfZero( IntRegister value1, Label lbl){
            this.value1=value1;
            this.lbl=lbl;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    test {this.value1}, {this.value1}");
            w.WriteLine($"    jz {lbl.value}  /* {lbl.comment} */");
        }
    }

}