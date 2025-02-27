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
            TableWriter.create();
            return;
        }

        string inp = File.ReadAllText(args[0]);
        var tokens = new List<Token>();
        var T = new Tokenizer(inp);

        TreeNode root = Parser.parse(T);
        
        root.collectClassNames();
        root.setNodeTypes();


        //debug output: Write the tree in JSON format
        var opts = new System.Text.Json.JsonSerializerOptions();
        opts.IncludeFields=true;
        opts.WriteIndented=true;
        opts.MaxDepth=1000000;
        string J = System.Text.Json.JsonSerializer.Serialize(root,opts);
        using(var w = new StreamWriter("tree.json")){
            w.WriteLine(J);
        }
    }
} //class

} //namespace