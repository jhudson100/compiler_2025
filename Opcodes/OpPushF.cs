namespace lab{

    public class OpPushF: Opcode {
        FloatRegister reg;
        StorageClass sclass;
        public OpPushF( FloatRegister reg, StorageClass sclass){
            this.reg=reg;
            this.sclass=sclass;
        }

        public override void output(StreamWriter w){
            w.WriteLine("    sub $8, %rsp  /* push float value */");
            w.WriteLine($"    movq {this.reg}, (%rsp)  /* push float value */");
            if( this.sclass != StorageClass.NO_STORAGE_CLASS )
                w.WriteLine($"    pushq ${(int)this.sclass}  /* storage class {this.sclass.ToString()}*/");
        }
    }


}