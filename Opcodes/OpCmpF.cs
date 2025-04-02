namespace lab{

    public class OpCmpF: Opcode {
        public OpCmpF(string cc, FloatRegister op1, FloatRegister op2){
        }

        public override void output(StreamWriter w){
            throw new Exception();
        }
    }

}