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
    } //Utils

} //namespace
