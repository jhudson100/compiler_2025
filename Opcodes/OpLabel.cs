
namespace lab{

    public class OpLabel : Opcode {
        Label lbl;
        public OpLabel(Label lbl){
            this.lbl = lbl;
        }
        public override void output(StreamWriter w)
        {
            w.WriteLine($"{this.lbl.value}:      /* {this.lbl.comment} */");
        }

    }


}
