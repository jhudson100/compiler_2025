namespace lab{

    public class OpPop: Opcode {
        IntRegister value;
        IntRegister sclass;
        bool onlyPopOne;

        public OpPop( IntRegister value, IntRegister sclass){
            this.value=value;
            this.sclass=sclass;
            onlyPopOne=false;
        }

        public OpPop( IntRegister value, StorageClass c){
            if( c != StorageClass.NO_STORAGE_CLASS )
                throw new Exception("Bad storage class");
            this.value = value;
            this.sclass = null;
            onlyPopOne=true;
        }
        public override void output(StreamWriter w){
            if( onlyPopOne == false ){
                if( this.sclass == null ){
                    w.WriteLine("    add $8, %rsp   /* discard storage class */");
                } else {
                    w.WriteLine($"    pop {this.sclass}  /* storage class */");
                }
            }
            w.WriteLine($"    pop {this.value}  /* value */");
        }
    }


}