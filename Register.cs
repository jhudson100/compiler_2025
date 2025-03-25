namespace lab{

    public class Register{
        public string name ;

        protected Register(string n){
            this.name=n;
        }

        public override string ToString()
        {
            return "%"+name;
        }

        public static readonly IntRegister rax = new IntRegister("rax","al");
        public static readonly IntRegister rbx = new IntRegister("rbx","bl");
        public static readonly IntRegister rcx = new IntRegister("rcx","cl");
        public static readonly IntRegister rdx = new IntRegister("rdx","dl");
        public static readonly IntRegister rsp = new IntRegister("rsp",null);
        public static readonly IntRegister rbp = new IntRegister("rbp",null);
        public static readonly IntRegister rsi = new IntRegister("rsi","sil");
        public static readonly IntRegister rdi = new IntRegister("rdi","dil");
        public static readonly IntRegister r8 = new IntRegister("r8","r8l");
        public static readonly IntRegister r9 = new IntRegister("r9","r9l");
        // public static readonly IntRegister r10 = new IntRegister("r10");
        // public static readonly IntRegister r11 = new IntRegister("r11");
        // public static readonly IntRegister r12 = new IntRegister("r12");
        // public static readonly IntRegister r13 = new IntRegister("r13");
        // public static readonly IntRegister r14 = new IntRegister("r14");
        // public static readonly IntRegister r15 = new IntRegister("r15");
        
        public static readonly FloatRegister xmm0 = new FloatRegister("xmm0");
        public static readonly FloatRegister xmm1 = new FloatRegister("xmm1");
        public static readonly FloatRegister xmm2 = new FloatRegister("xmm2");
        public static readonly FloatRegister xmm3 = new FloatRegister("xmm3");
        
    }

    public class IntRegister : Register{
        public readonly string lowbyte;
        public IntRegister(string name, string lowname): base(name)
        {
            this.lowbyte = "%"+lowname;
        }

    }

    public class FloatRegister : Register{
        public FloatRegister(string name): base(name)
        {}
    }
}