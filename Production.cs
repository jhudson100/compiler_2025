namespace lab{

public class Production {
    private static int counter=0;

    // foo :: bar baz bam
    public string lhs;      //foo
    public string[] rhs;    //[ bar, baz, bam]
    public PSpec pspec;
    public readonly int unique;

    public Production(PSpec pspec, string lhs, string[] rhs){
        this.pspec=pspec;
        this.lhs=lhs;
        this.rhs=rhs;
        this.unique = counter++;
    }
    public override string ToString(){
        string rhsStr;
        if( this.rhs.Length == 0 )
            rhsStr = "\u03bb";      //lambda
        else
            rhsStr = String.Join(' ',this.rhs);
        return $"{this.lhs} :: {rhsStr}";
    }
} //class Production

}//namespace