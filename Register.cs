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

        public static readonly IntRegister rax = new IntRegister("rax");
        public static readonly IntRegister rbx = new IntRegister("rbx");
        public static readonly IntRegister rcx = new IntRegister("rcx");
        public static readonly IntRegister rdx = new IntRegister("rdx");
        public static readonly IntRegister rsp = new IntRegister("rsp");
        public static readonly IntRegister rbp = new IntRegister("rbp");
        public static readonly IntRegister rsi = new IntRegister("rsi");
        public static readonly IntRegister rdi = new IntRegister("rdi");
        public static readonly IntRegister r8 = new IntRegister("r8");
        public static readonly IntRegister r9 = new IntRegister("r9");
        public static readonly IntRegister r10 = new IntRegister("r10");
        public static readonly IntRegister r11 = new IntRegister("r11");
        public static readonly IntRegister r12 = new IntRegister("r12");
        public static readonly IntRegister r13 = new IntRegister("r13");
        public static readonly IntRegister r14 = new IntRegister("r14");
        public static readonly IntRegister r15 = new IntRegister("r15");
        
        public static readonly FloatRegister xmm0 = new FloatRegister("xmm0");
        public static readonly FloatRegister xmm1 = new FloatRegister("xmm1");
        public static readonly FloatRegister xmm2 = new FloatRegister("xmm2");
        public static readonly FloatRegister xmm3 = new FloatRegister("xmm3");
        
    }

    public class IntRegister : Register{
        public IntRegister(string name): base(name)
        {}
    }

    public class FloatRegister : Register{
        public FloatRegister(string name): base(name)
        {}
    }
}