namespace lab{

    public class OpPush: Opcode {
        IntRegister reg;
        StorageClass sclass;
        public OpPush( IntRegister reg, StorageClass sclass){
            this.reg=reg;
            this.sclass=sclass;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    push {this.reg}  /* value */");
            if( this.sclass != StorageClass.NO_STORAGE_CLASS )
                w.WriteLine($"    push ${(int)this.sclass}  /* storage class {this.sclass.ToString()}*/");
        }
    }


}