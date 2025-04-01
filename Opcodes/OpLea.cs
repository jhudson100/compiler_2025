namespace lab{

    public class OpLea: Opcode {
        IntRegister src;
        int offset ;
        IntRegister dest;
        string comment;

        public OpLea( IntRegister src, int offset, IntRegister dest, string comment){
            this.src=src;
            this.offset=offset;
            this.dest=dest;
            this.comment=comment;
        }

        public override void output(StreamWriter w){
            w.WriteLine($"    lea ${offset}({src}), {dest}  /* {comment} */");
        }
    }

}