public static class Utils{
    public static void error(Token t, string msg){
        Console.WriteLine($"Error at line {t.line}: {msg}");
        Environment.Exit(1);
    }
}