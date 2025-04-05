namespace lab{

    public class OpNegF: Opcode {
        FloatRegister reg; 
        FloatRegister temp;
        public OpNegF( FloatRegister reg, FloatRegister temp){
            this.reg=reg;
            this.temp=temp;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    xorps {temp}, {temp}  /* set register to zero */");
            w.WriteLine($"    subps {reg}, {temp}  /* negation */");
            w.WriteLine($"    movq {temp},{reg}  /* put result back where it belongs */");
        }
    }

}