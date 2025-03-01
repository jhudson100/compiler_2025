namespace lab{

public class ItemSet{
    public HashSet<LRItem> items;
    public override int GetHashCode()
    {
        //FIXME: Write this
        return 0;
    }
    public override bool Equals(object obj)
    {
        if( Object.ReferenceEquals(obj,null) )
            return false;
        ItemSet S = obj as ItemSet;
        if( Object.ReferenceEquals(S,null) )
            return false;       
        //FIXME: Write this
        return true;
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
        return String.Join("\n",L.ToArray());
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
        string r = $"State {this.unique}\n";
        r += this.label;
        r += "---------------\n";
        foreach( string sym in this.transitions.Keys){
            DFAState q = transitions[sym];
            r += $"{sym} -> {q.unique}";
        }
        return r;
    }

}

public static class DFA{
    public static List<DFAState> allStates = new();
    
    static void dump(string filename){
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
                    sw.WriteLine($"{starting} -> {ending} [label=\"{sym}\"]");
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

    } //makeDFA

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