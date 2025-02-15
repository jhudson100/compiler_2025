using System.Collections.Immutable;

namespace lab{

public class CompilersAreGreat{
    private const int V = 3;

    public static void Main(string[] args){

        //initialize our grammar
        Terminals.makeThem();
        Productions.makeThem();

        Grammar.check();

        // Grammar.computeNullableAndFirst();
        
        // Grammar.dump();

        return;
        
        string inp = File.ReadAllText(args[0]);
        var tokens = new List<Token>();
        var T = new Tokenizer(inp);
        while(true){
            Token tok = T.next();
            if( tok == null )
                break;
            tokens.Add(tok);
        }
        Console.WriteLine("[");
        for(int i=0;i<tokens.Count;++i){
            Console.Write(tokens[i]);
            if( i != tokens.Count-1 )
                Console.Write(",");
            Console.WriteLine();
        }
        Console.WriteLine("]");
    }
} //class

} //namespace