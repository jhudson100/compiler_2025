namespace lab{

public class LRItem{
    public readonly Production production;
    public readonly int dpos;

    public LRItem(Production production, int dpos){
        this.production = production;
        this.dpos=dpos;
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
}

}