namespace lab{

    public class OpJmpIfNonzero: Opcode {
        IntRegister value1;
        Label lbl;
        public OpJmpIfNonzero( IntRegister value1, Label lbl){
            this.value1=value1;
            this.lbl=lbl;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    test {this.value1}, {this.value1}");
            w.WriteLine($"    jnz {lbl.value}  /* {lbl.comment} */");
        }
    }

}