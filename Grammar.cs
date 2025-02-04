namespace lab{

public static class Grammar{
    public static List<Terminal> terminals = new();
    public static HashSet<string> allTerminals = [];
    public static List<Production> productions = new();
    public static HashSet<string> allNonterminals = new();
    public static HashSet<string> nullable = new();
    public static Dictionary<string,HashSet<string>> first = new();

    public static void addTerminals( Terminal[] terminals){
        foreach(var t in terminals){
            if( isTerminal( t.sym ) )
                throw new Exception("YOU ARE MISTAKE");
            Grammar.terminals.Add(t);
            allTerminals.Add(t.sym);
        }
    }

    public static bool isTerminal(string sym){
        return allTerminals.Contains(sym);
    }
    public static bool isNonterminal(string sym){
        return allNonterminals.Contains(sym);
    }

    public static void defineProductions(PSpec[] specs){
        //parse stuff out of our pspec's and put it somewhere
        foreach( var psec in specs){
            //do something...
        }
    }

    public static void check(){
        //check for problems. panic if so.
        foreach( Production p in productions){
            foreach( string sym in p.rhs){
                if(!isTerminal(sym) && !isNonterminal(sym)){
                    throw new Exception("Undefined symbol: "+sym);
                }
            }
        }
    }

    public static void dump(){
        //dump grammar stuff to the screen (debugging)
        foreach( var p in productions ){
            Console.WriteLine(p);
        }
        Console.Write("NULLABLE: FINISH ME");
        Console.WriteLine();
        foreach(var sym in first.Keys){
            Console.Write($"first[{sym}] = ");
            Console.WriteLine("FINISH ME");
        }
    }

    public static void computeNullableAndFirst(){
        var flag = true;
        while(flag){
            flag=false;
            //TODO: Finish computing nullable
        }
        
        foreach( var sym in Grammar.allTerminals){
            first[sym] = new();
            first[sym].Add(sym);
        }
        foreach(var sym in Grammar.allNonterminals){
            first[sym] = new();
        }

        flag=true;
        while(flag){
            flag=false;
            //TODO: Finish computing first
        }
    }
} //end class Grammar




} //end namespace