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


        public IntRegister valueRegister(){
            return this.value;
        }


        public IntRegister storageClassRegister(){
            return this.sclass;
        }

        public bool popsStorageClass(){
            return this.onlyPopOne == false;
        }
        
        public void doNotPopStorageClass(){
            this.onlyPopOne = true;
        }

        public bool discardsStorageClass(){
            return onlyPopOne == false && this.sclass == null;
        }

        public override bool touchesStack(){
           return true;
        }

        public override void output(StreamWriter w){
            if( onlyPopOne == false ){
                if( this.sclass == null ){
                    w.WriteLine("    add $8, %rsp   /* discard storage class */");
                } else {
                    w.WriteLine($"    pop {this.sclass}  /* storage class */");
                }
            }
            if( this.value == null )
                w.WriteLine("    add $8, %rsp  /* discard value */");
            else
                w.WriteLine($"    pop {this.value}  /* value */");
        }
    }


}