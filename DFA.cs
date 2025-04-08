
namespace lab{

public class ItemSet{
    public HashSet<LRItem> items;
    public override int GetHashCode()
    {
        int h=0;
        foreach(var I in items){
            h ^= I.GetHashCode();
        }
        return h;
    }
    public override bool Equals(object obj)
    {
        if( Object.ReferenceEquals(obj,null) )
            return false;
        ItemSet S = obj as ItemSet;
        if( Object.ReferenceEquals(S,null) )
            return false;
        return items.SetEquals(S.items);
    }

    public static bool operator==(ItemSet o1, ItemSet o2){
        if( Object.ReferenceEquals(o1, null )){
            return Object.ReferenceEquals(o2,null);
        }
        return o1.Equals(o2);
    }
    public static bool operator!=(ItemSet I1, ItemSet I2){
        return !(I1 == I2);
    }
    public override string ToString()
    {
        var L = new List<string>();
        foreach(var I in this.items ){
            L.Add(I.ToString());
        }
        return String.Join("\n",L.ToArray()) + "\n";
    }

}

public class DFAState{
    private static int counter=0;
    public ItemSet label;
    public readonly int unique;
    public Dictionary<string, DFAState> transitions = new();

    public DFAState(ItemSet label){
        this.label = label;
        this.unique = counter++;
    }
    public override string ToString()
    {
        string r = "";
        r += $"State {this.unique}\n";
        r += this.label;
        foreach( string sym in this.transitions.Keys){
            DFAState q = transitions[sym];
            r += $"{sym} \u2192 {q.unique}\n";
        }
        return r;
    }

}

public static class DFA{
    public static List<DFAState> allStates = new();
    
    public static void dump(string filename){
        using(var sw = new StreamWriter(filename)){
            sw.WriteLine("digraph d{");

            foreach( DFAState q in allStates ){
                string x = q.label.ToString();
                x = x.Replace("\n","\\n");
                sw.WriteLine($"q{q.unique} [label=\"{x}\"];");
            }

            foreach( DFAState q in allStates ){
                string starting = $"q{q.unique}";
                foreach( string sym in q.transitions.Keys){
                    DFAState q2 = q.transitions[sym];
                    string ending = $"q{q2.unique}";
                    sw.WriteLine($"{starting} \u2192 {ending} [label=\"{sym}\"]");
                }
            }

            sw.WriteLine("}");

        }

    }

    static ItemSet computeClosure(HashSet<LRItem> kernel)
    {
        var s = new HashSet<LRItem>();
        s.UnionWith(kernel);
        bool keeplooping = true;
        while( keeplooping ){
            keeplooping=false;
            HashSet<LRItem> tmp = new();
            foreach(LRItem I in s){
                if( I.dposAtEnd() )
                    continue;
                string sym = I.symbolAfterDistinguishedPosition;
                if( Grammar.allNonterminals.Contains(sym)){
                    //sym is a nonterminal
                    foreach( Production p in Grammar.productionsByLHS[sym]){
                        var I2 = new LRItem(p,0 );
                        tmp.Add(I2);
                    }
                }
            }
            int sizeBefore= s.Count;
            s.UnionWith(tmp);
            int sizeAfter = s.Count;
            keeplooping = (sizeAfter > sizeBefore);
        }
        var rv = new ItemSet();
        rv.items = s;
        return rv;
    }

    public static void makeDFA(){
        int productionNumber = Grammar.defineProductions(
            new PSpec[] {
                new PSpec("S' :: S")
            }
        ); 

        Dictionary< ItemSet , DFAState> statemap = new();

        Production P = Grammar.productions[productionNumber];
        LRItem I = new LRItem( P, 0);
        I.lookahead.Add("$");
        DFAState startState = new DFAState( 
            computeClosure(
                new HashSet<LRItem>(){I} 
            )
        );    
        allStates.Add(startState);
        statemap[startState.label] = startState;

        var todo = new Stack<DFAState>();
        todo.Push(startState);

        while( todo.Count > 0 ){
            DFAState q = todo.Pop();
            var tr = getOutgoingTransitions(q);
            foreach(string sym in tr.Keys){
                var lbl = computeClosure(tr[sym]);
                if( !statemap.ContainsKey(lbl)){
                    var q2 = new DFAState(lbl);
                    todo.Push(q2);
                    statemap[q2.label] = q2;
                    allStates.Add(q2);
                }
                if( q.transitions.ContainsKey(sym) )
                    throw new Exception("BUG!");
                q.transitions[sym] = statemap[lbl];
            }
        }

        computeLookaheads();
    } //makeDFA

    static void computeLookaheads(){
        bool keeplooping=true;
        while(keeplooping){
            keeplooping=false;
            foreach( DFAState Q in allStates){
                foreach( LRItem I in Q.label.items){
                    if( I.dposAtEnd() == false ){
                        string x = I.production.rhs[I.dpos];
                        DFAState Q2 = Q.transitions[x];
                        LRItem I2 = findItemCreatedFromItem(Q2,I);
                        int size = I2.lookahead.Count;
                        I2.lookahead.UnionWith(I.lookahead);
                        if( I2.lookahead.Count != size )
                            keeplooping=true;
        
                        if( Grammar.isNonterminal(x) ){
                            HashSet<string> syms = findfirst(I);
                            foreach( Production P in Grammar.productionsByLHS[x]){
                                LRItem I3 = findItemCreatedByProduction(Q,P);
                                size = I3.lookahead.Count;
                                I3.lookahead.UnionWith(syms);
                                if( I3.lookahead.Count != size )
                                    keeplooping=true;
                            }
                        }
                    }
                }
            }
        }
    }

    static LRItem findItemCreatedByProduction(DFAState Q, Production P){
        foreach(LRItem I in Q.label.items){
            if( I.production == P && I.dpos == 0 )
                return I;
        }
        throw new Exception("Logic error");
    }

    static HashSet<string> findfirst(LRItem I){
        var f = new HashSet<string>();
        for(int i=I.dpos+1;i<I.production.rhs.Length;++i){
            string sym = I.production.rhs[i];
            f.UnionWith(Grammar.first[sym]);
            if( !Grammar.nullable.Contains(sym))
                return f;
        }
        f.UnionWith(I.lookahead);
        return f;
    }

    static LRItem findItemCreatedFromItem( DFAState Q2, LRItem I ){
        foreach( LRItem I2 in Q2.label.items){
            if (I.production==I2.production && I.dpos+1 == I2.dpos){
                return I2;
            }
        }
        throw new Exception("Logic error");
    }

    static Dictionary<string, HashSet<LRItem> > getOutgoingTransitions(DFAState q){
        var tr = new Dictionary<string, HashSet<LRItem> >();
        foreach( LRItem I in q.label.items){
            if( !I.dposAtEnd() ) {
                string sym = I.symbolAfterDistinguishedPosition;
                
                if( !tr.ContainsKey(sym))
                    tr[sym] = new();

                //we have an outgoing transition on the symbol sym
                LRItem I2 = new LRItem( I.production, I.dpos+1);
                tr[sym].Add( I2 );
            }
        }
        return tr;
    }

} //DFA class


} //namespace lab
