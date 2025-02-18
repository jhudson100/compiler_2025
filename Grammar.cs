namespace lab{

public static class Grammar{
    public static List<Terminal> terminals = new();
    public static HashSet<string> allTerminals = [];
    public static List<Production> productions = new();
    public static HashSet<string> allNonterminals = new();
    public static Dictionary<string,List<Production>> productionsByLHS = new();

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

    public static int defineProductions(PSpec[] specs){
        //Return the index of the first production that we added
        int howMany = productions.Count;
        foreach( var pspec in specs){
            var idx = pspec.spec.IndexOf("::");
            if( idx == -1 )
                throw new Exception("No :: in production spec");
            string lhs = pspec.spec.Substring(0,idx).Trim();
            Grammar.allNonterminals.Add(lhs);
            string rhss = pspec.spec.Substring(idx+2).Trim();
            string[] rhsl = rhss.Trim().Split("|",StringSplitOptions.RemoveEmptyEntries );
            foreach( string tmp in rhsl){
                string[] rhs = tmp.Trim().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if( rhs.Length == 1 && (rhs[0] == "lambda" || rhs[0] == "\u03bb" ) )
                    rhs = new string[0];
                for(int i=0;i<rhs.Length;++i){
                    rhs[i]=rhs[i].Trim();
                }
                var p = new Production(pspec, lhs, rhs);
                Grammar.productions.Add( p );
                if(! productionsByLHS.Keys.Contains(lhs))
                    productionsByLHS[lhs]= new();
                productionsByLHS[lhs].Add(p);
            }
        }
        return howMany;
    }

    public static void computeNullableAndFirst(){
        //FIXME: FINISH
    }

    public static void check(){
        //check for problems. panic if so.
        var unknown = new HashSet<string>();
        foreach( Production p in productions){
            foreach( string sym in p.rhs){
                if(!isTerminal(sym) && !isNonterminal(sym)){
                    unknown.Add(sym);
                }
            }
        }
        foreach( string sym in unknown){
            Console.WriteLine("WARNING: Undefined symbol: "+sym);
        }

    }

    public static void dump(){
        //dump grammar stuff to the screen (debugging)
        foreach( var p in productions ){
            Console.WriteLine(p);
        }
    }

} //end class Grammar




} //end namespace