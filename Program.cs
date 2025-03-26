using System.Collections.Immutable;

namespace lab{

public class CompilersAreGreat{
    private const int V = 3;

    public static void Main(string[] args){

        //initialize our grammar
        Terminals.makeThem();
        Productions.makeThem();
        ProductionsExpr.makeThem();
        
        if( args.Contains("-g") ){
            Grammar.check();
            Grammar.computeNullableAndFirst();
            DFA.makeDFA(); //time consuming
            TableWriter.create();
            return;
        }

        TreeNode root=null;

        for(int i=0;i<args.Length;++i){
            if( args[i] == "-t" ){
                i++;
                if( i >= args.Length ){
                    Console.WriteLine("-t requires an argument");
                    Environment.Exit(1);
                }
                string treefile = args[i];
                using(var r = new StreamReader(treefile)){
                    string data = r.ReadToEnd();
                    var dopts = new System.Text.Json.JsonSerializerOptions();
                    dopts.IncludeFields=true;
                    dopts.WriteIndented=true;
                    dopts.MaxDepth=1000000;
                    root = System.Text.Json.JsonSerializer.Deserialize<TreeNode>(data,dopts);
                    root.setParents();
                }
            }
        }

        if( root == null){
            string inp = File.ReadAllText(args[0]);
            var tokens = new List<Token>();
            var T = new Tokenizer(inp);
            root = Parser.parse(T);
        }
        
        root.collectClassNames();
        root.setNodeTypes();

        root.generateCode();

        using(var w = new StreamWriter("out.asm")){
            Asm.output(w);
        }
        Run.compile("out.asm");


        //root.removeUnitProductions();     

        //Console.WriteLine("The tree:");
        //root.print();
        
        //debug output: Write the tree in JSON format
        var opts = new System.Text.Json.JsonSerializerOptions();
        opts.IncludeFields=true;
        opts.WriteIndented=true;
        opts.MaxDepth=1000000;
        string J = System.Text.Json.JsonSerializer.Serialize(root,opts);
        using(var w = new StreamWriter("tree.json")){
            w.WriteLine(J);
            //root.toJson(w);
        }
    }
} //class

} //namespace