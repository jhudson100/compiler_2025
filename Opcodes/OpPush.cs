namespace lab{

    public class OpPush: Opcode {
        IntRegister reg;
        IntRegister sclassR=null;
        StorageClass sclass;

        public OpPush( IntRegister reg, StorageClass sclass){
            this.reg=reg;
            this.sclass=sclass;
        }

        public OpPush( IntRegister reg, IntRegister sclass){
            this.reg=reg;
            this.sclassR=sclass;
        }
        
        public int storageClassValue(){
            return (int)this.sclass ;
        }
        
        public IntRegister valueRegister(){
            return reg;
        }

        public IntRegister storageClassRegister(){
            return this.sclassR;        //if we're pushing constant, this is null
        }

        public void doNotPushStorageClass(){
            this.sclassR=null;
            this.sclass = StorageClass.NO_STORAGE_CLASS;
        }
        
        public bool pushesStorageClass(){
            return this.sclassR == null && this.sclass != StorageClass.NO_STORAGE_CLASS;
        }

        public override bool touchesStack(){
           return true;
        }


        public override void output(StreamWriter w){
            w.WriteLine($"    push {this.reg}  /* value */");
            if( this.sclassR != null ){
                w.WriteLine($"    push {this.sclassR}  /* storage class */");
            } else {
                if( this.sclass != StorageClass.NO_STORAGE_CLASS )
                    w.WriteLine($"    push ${(int)this.sclass}  /* storage class {this.sclass.ToString()}*/");
            }
        }
    }


}