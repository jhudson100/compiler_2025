namespace lab{

    public class OpRet: Opcode {
        public OpRet( ){
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    ret");
        }
    }


}