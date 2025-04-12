namespace lab{
    
    public static class Utils{
        public static void error(string msg){
            Utils.error( (Token)null, msg );
        }
        public static void error(TreeNode n, string msg){
            Utils.error( n.firstToken(), msg );
        }
        public static void error(Token t, string msg){
            Console.WriteLine($"Error at line {t?.line}: {msg}");
            Environment.Exit(1);
        }
        public static void epilogue(Token t){
            Asm.add(new OpComment( "Epilogue at line "+t.line));
            Asm.add( new OpMov( src: Register.rbp, dest: Register.rsp));
            Asm.add( new OpPop( Register.rbp, StorageClass.NO_STORAGE_CLASS));
            Asm.add( new OpRet());
        }
        
    } //Utils

} //namespace
