namespace lab{

    public class OpRet: Opcode {
        public OpRet( ){
        }


        public override bool touchesStack(){
           return true;
        }

        public override bool transfersControl(){
            return false;
        }


        public override void output(StreamWriter w){
            w.WriteLine($"    ret");
        }
    }


}