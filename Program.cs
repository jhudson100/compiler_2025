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

        bool optimize=false;
        string infile;

        if( args[0] == "-O" ){
            optimize=true;
            infile = args[1];
        } else {
            infile = args[0];
        }


        string inp = File.ReadAllText(infile);
        var tokens = new List<Token>();
        var T = new Tokenizer(inp);
        TreeNode root = Parser.parse(T);

        SymbolTable.populateBuiltins();
        
        root.collectClassNames();
        root.collectFunctionNames();
        root.setNodeTypes();
        root.returnCheck();
        root.generateCode();


        if(optimize){
            int num;
            do{
                num = Optimizer.applyAll();
                Console.WriteLine("Optimizer pass: Applied "+num+" optimizations");
            } while(num > 0 );
        }



        using(var w = new StreamWriter("out.asm")){
            Asm.output(w);
        }

        Run.compile("out.asm");

        //root.removeUnitProductions();
        //root.print();
        //using(var w = new StreamWriter("tree.json")){
        //    root.toJson(w);
        //}
    }
} //class

} //namespace