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

        public static void returnCheck(TreeNode n, NodeType actualType){
            var p = n.parent;
            while(p != null && p.sym != "funcdecl" ){
                p=p.parent;
            }
            if(p==null){
                Utils.error(n,"Return outside of a function");
            }
            var expectedReturnType = p["optionalReturn"].nodeType;
            if( expectedReturnType == null )
                throw new Exception("Didn't set type of return?");
            if( actualType != expectedReturnType )
                Utils.error(n,"Return type mismatch");
        }

        public delegate bool WalkCallback(TreeNode n);
        public static void walk(TreeNode n, WalkCallback f){
            if( !f(n) )
                return;
            foreach(var c in n.children){
                walk(c,f);
            }
        }
        
    } //Utils

} //namespace
