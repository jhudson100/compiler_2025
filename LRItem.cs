namespace lab{

public class LRItem{
    public readonly Production production;
    public readonly int dpos;
    public HashSet<string> lookahead = new();
    public LRItem(Production production, int dpos){
        this.production = production;
        this.dpos=dpos;
    }

    public bool dposAtEnd(){
        return this.dpos == this.production.rhs.Length;
    }

    public string symbolAfterDistinguishedPosition {
        get {
            return this.production.rhs[this.dpos];
        }
    }

    public override int GetHashCode()
    {
        return this.production.unique ^ (dpos<<16);
    }

    public override bool Equals(object obj)
    {
        if( Object.ReferenceEquals(obj,null) )
            return false;
        LRItem I = obj as LRItem;
        if( Object.ReferenceEquals(I,null) )
            return false;       //obj was not an LRItem
        return this.production.unique == I.production.unique &&
               this.dpos == I.dpos;
    }

    public static bool operator==(LRItem o1, LRItem o2){
        if( Object.ReferenceEquals(o1, null )){
            return Object.ReferenceEquals(o2,null);
        }
        return o1.Equals(o2);
    }
    public static bool operator!=(LRItem o1, LRItem o2){
        return !(o1==o2);
    }
    public override string ToString()
    {
        string s = $"{this.production.lhs} :: ";
        for(int i=0;i<this.dpos;++i){
            s += this.production.rhs[i] + " ";
        }
        s += "\u2022";
        for(int i=this.dpos;i<this.production.rhs.Length;++i){
            s += " "+this.production.rhs[i];
        }
        s += " \u2551 ";
        s += String.Join(" ",this.lookahead);
        return s;
    }

}

}