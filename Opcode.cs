namespace lab
{

    public abstract class Opcode
    {
        public abstract void output(StreamWriter w);

        public virtual bool touchesStack()
        {
            return false;
        }
        public virtual bool transfersControl()
        {
            return false;
        }
        
        public virtual bool writesToRegister(IntRegister reg)
        {
            throw new NotImplementedException(GetType().ToString());
        }
        public virtual bool readsFromRegister(IntRegister reg)
        {
            throw new NotImplementedException(GetType().ToString());
        }
    }

}