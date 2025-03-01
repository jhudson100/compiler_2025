namespace lab{

public static class Grammar{
    public static List<Terminal> terminals = new();
    public static HashSet<string> allTerminals = [];
    public static List<Production> productions = new();
    public static HashSet<string> allNonterminals = new();
    public static HashSet<string> nullable = new();
    public static Dictionary<string,HashSet<string>> first = new();
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
                var P = new Production(pspec, lhs, rhs);
                Grammar.productions.Add( P );
                if( !Grammar.productionsByLHS.ContainsKey(P.lhs) )
                    Grammar.productionsByLHS[P.lhs] = new();
                Grammar.productionsByLHS[P.lhs].Add(P);
            }
        }
        return howMany;
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

    public static void computeNullableAndFirst(){
        bool keeplooping=true;
        while(keeplooping){
            keeplooping=false;
            foreach( Production P in productions){
                if( nullable.Contains(P.lhs) )
                    continue;
                bool foundNonNullable=false;
                foreach(string sym in P.rhs){
                    if( !nullable.Contains(sym) ){
                        foundNonNullable=true;
                        break;
                    }
                }
                if(!foundNonNullable){
                    nullable.Add(P.lhs);
                    keeplooping=true;
                }
            }
        }

        foreach(string sym in allTerminals){
            first[sym] = new (){ sym };
        }
        foreach(string sym in allNonterminals){
            first[sym] = new();
        }

        keeplooping=true;
        while(keeplooping){
            keeplooping=false;
            foreach( Production P in productions ){
                foreach( string sym in P.rhs ){
                    int s1 = first[P.lhs].Count;
                    first[P.lhs].UnionWith( first[sym] );
                    int s2 = first[P.lhs].Count;
                    if( s1 != s2 )
                        keeplooping=true;
                    if(!nullable.Contains(sym))
                        break;
                }
            }
        }

    }

    public static void dump(){
        //dump grammar stuff to the screen (debugging)
        foreach( var p in productions ){
            Console.WriteLine(p);
        }
        Console.Write("Nullable: ");
        Console.WriteLine( String.Join(" , ", nullable ) );
        foreach(string sym in first.Keys){
            Console.Write($"first[{sym}] = ");
            Console.WriteLine( String.Join(" , ", first[sym] ) );
        }
    }

} //end class Grammar




} //end namespace