namespace lab{

    public class OpJmp: Opcode {
        Label lbl;
        public OpJmp( Label lbl){
            this.lbl=lbl;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    jmp {lbl.value}  /* {lbl.comment} */");
        }
    }

}