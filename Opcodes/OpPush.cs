namespace lab{

    public class OpPush: Opcode {
        IntRegister reg;
        IntRegister sclassR=null;
        StorageClass sclass;
        string comment;

        public OpPush( IntRegister reg, StorageClass sclass, string comment=""){
            this.reg=reg;
            this.sclass=sclass;
            this.comment=comment;
        }

        public OpPush( IntRegister reg, IntRegister sclass, string comment=""){
            this.reg=reg;
            this.sclassR=sclass;
            this.comment=comment;
        }

        public override void output(StreamWriter w){
            string comment="";
            if( this.comment.Length>0 ){
                comment = ": "+this.comment;
            }
            w.WriteLine($"    push {this.reg}  /* value{comment} */");
            if( this.sclassR != null ){
                w.WriteLine($"    push {this.sclassR}  /* storage class{comment} */");
            } else {
                if( this.sclass != StorageClass.NO_STORAGE_CLASS )
                    w.WriteLine($"    push ${(int)this.sclass}  /* storage class {this.sclass.ToString()}{comment} */");
            }
        }
    }


}