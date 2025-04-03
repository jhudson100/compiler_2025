using System.Collections.Immutable;

namespace lab{

public class CompilersAreGreat{
    private const int V = 3;

    public static void Main(string[] args){

        //initialize our grammar
        Terminals.makeThem();
        Productions.makeThem();
        ProductionsExpr.makeThem();

        if( args.Length == 1 && args[0] == "-g" ){
            Grammar.check();
            Grammar.computeNullableAndFirst();
            DFA.makeDFA(); //time consuming
            DFA.dump("dfa.txt");
            TableWriter.create(Console.Out);
            // foreach( var q in DFA.allStates ){
            //     Console.WriteLine(q);
            // }
            return;
        }


        string inp = File.ReadAllText(args[0]);
        var tokens = new List<Token>();
        var T = new Tokenizer(inp);
        TreeNode root = Parser.parse(T);


        root.collectClassNames();
        root.collectFunctionNames();
        root.setNodeTypes();
    
        root.removeUnitProductions();
        root.print();
        using(var w = new StreamWriter("tree.json")){
            root.toJson(w);
        }
    }
} //class

} //namespace