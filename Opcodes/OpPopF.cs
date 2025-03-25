namespace lab{

    public class OpPopF: Opcode {
        FloatRegister value;
        IntRegister sclass;
        public OpPopF( FloatRegister value, IntRegister sclass){
            this.value=value;
            this.sclass=sclass;
        }

        public override void output(StreamWriter w){
            if( this.sclass == null ){
                w.WriteLine("    add $8, %rsp   /* discard storage class */");
            } else {
                w.WriteLine($"    pop {this.sclass}  /* storage class */");
            }

            w.WriteLine($"    mov (%rsp), {this.value}  /* pop floating point value */");
            w.WriteLine( "    add $8, %rsp   /* finish popping float value */");

        }
    }


}