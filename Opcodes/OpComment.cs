
namespace lab{

    public class OpComment : Opcode {
        string txt;
        public OpComment(string txt){
            this.txt = txt;
        }
        public override void output(StreamWriter w)
        {
            w.WriteLine($"    /* {this.txt} */");
        }

    }


}
