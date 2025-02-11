using System.Collections.Immutable;

namespace lab{

public class CompilersAreGreat{
    private const int V = 3;

    public static void Main(string[] args){

        // ImmutableHashSet<int> x1 = ImmutableHashSet.Create<int>(1,2, V);
        // var x2 = ImmutableHashSet.Create<int>(1,2,3);
        // Console.WriteLine(x1.GetHashCode());
        // Console.WriteLine(x2.GetHashCode());
        // return;



        //initialize our grammar
        Terminals.makeAllOfTheTerminals();
        Productions.makeThem();

        Grammar.check();

        Grammar.computeNullableAndFirst();
        
        Grammar.dump();

        // return;
        
        string inp = File.ReadAllText(args[0]);
        var tokens = new List<Token>();
        var T = new Tokenizer(inp);
        while(true){
            Token tok = T.next();
            if( tok == null )
                break;
            tokens.Add(tok);
        }
        foreach(var t in tokens){
            Console.WriteLine(t);
        }
    }
} //class

} //namespace