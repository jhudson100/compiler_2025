using System.Collections.Immutable;

namespace lab{

public class CompilersAreGreat{
    private const int V = 3;

    public static void Main(string[] args){


var root = new TreeNode("sum",-1);
var sumA = new TreeNode("sum",-1);
var plusA = new TreeNode( new Token("PLUS","+",1) );
var num3 = new TreeNode( new Token("NUM","3",1) );
root.appendChild(sumA);
root.appendChild(plusA);
root.appendChild(num3);

var sumB = new TreeNode("sum",-1);
var plusB = new TreeNode( new Token("PLUS","+",1) );
var num2 = new TreeNode( new Token("NUM","2",1) );
sumA.appendChild(sumB);
sumA.appendChild(plusB);
sumA.appendChild(num2);

var num1 = new TreeNode( new Token("NUM","1",1) );
sumB.appendChild(num1);

var fooby = new TreeNode("fooby",-1);
num1.appendChild(fooby);
num2.appendChild(new TreeNode("dooby",-1));
num3.appendChild(new TreeNode("doo",-1));
fooby.appendChild(new TreeNode("nooby",-1));
num1.appendChild(new TreeNode("blargh",-1));

root.print();

return;


        // ImmutableHashSet<int> x1 = ImmutableHashSet.Create<int>(1,2, V);
        // var x2 = ImmutableHashSet.Create<int>(1,2,3);
        // Console.WriteLine(x1.GetHashCode());
        // Console.WriteLine(x2.GetHashCode());
        // return;

        //initialize our grammar
        Terminals.makeAllOfTheTerminals();
        Productions.makeThem();

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

        TreeNode rootx = Parser.parse(T);

    }
} //class

} //namespace