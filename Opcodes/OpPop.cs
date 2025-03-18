namespace lab{

    public class OpPop: Opcode {
        IntRegister value;
        IntRegister sclass;
        public OpPop( IntRegister value, IntRegister sclass){
            this.value=value;
            this.sclass=sclass;
        }

        public override void output(StreamWriter w){
            if( this.sclass == null ){
                w.WriteLine("    add $8, %rsp   /* discard storage class */");
            } else {
                w.WriteLine($"    pop {this.sclass}  /* storage class */");
            }
            w.WriteLine($"    pop {this.value}  /* value */");
        }
    }


}