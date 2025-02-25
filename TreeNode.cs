namespace lab{

public class TreeNode{
    public string sym;  //terminal name or nonterminal
                        //"NUM", "cond"
    public Token token; //only meaningful for terminals

    public List<TreeNode> children = new();

    public int productionNumber;

    public TreeNode parent = null;


    Production production {
        get {
            if( this.productionNumber >= 0 )
                return Grammar.productions[this.productionNumber];
            return null;
        }
    }

    public TreeNode(string sym, Token tok, int prodNum){
        this.sym=sym;
        this.token = tok;
        this.productionNumber = prodNum;
    }

    //nonterminal node
    public TreeNode(string sym, int prodNum) : this(sym,null,prodNum){}

    //terminal node
    public TreeNode(Token tok) : this( tok.sym, tok, -1 ){}

    public void appendChild(TreeNode n){
        n.parent = this;
        this.children.Add(n);
    }

    public void toJson(StreamWriter w){
        w.WriteLine("{");
        w.WriteLine( $"\"sym\" : \"{this.sym}\",");
        w.WriteLine( $"\"token\" : ");
        //TODO: this.token.toJson(w);
        w.WriteLine(",");
        w.WriteLine( "\"children\": [");
        for(int i=0;i<this.children.Count;i++){
            this.children[i].toJson(w);
            if( i != this.children.Count-1)
                w.WriteLine(",");
        }
        w.WriteLine("],");
        w.WriteLine( $"\"productionNumber\" : \"{this.productionNumber}\",");
        w.WriteLine("}");
    }

    public void print(string prefix=""){
        
        string HLINE = "─"; // (Unicode \u2500)
        string VLINE = "│";  //(\u2502)
        string TEE = "├";  //(\u251c)
        string ELL = "└"; // (\u2514) 

        bool lastChild = this.parent != null && this == this.parent.children[^1];
        //if this node is the last child
        if( this.parent == null ){
            //root
            Console.WriteLine(this.ToString());
         } else {
            if( lastChild ){
                Console.WriteLine(prefix+"  "+ELL+HLINE+this.ToString());
            } else {
                Console.WriteLine(prefix+"  "+TEE+HLINE+this.ToString());
            }
        }

        foreach(var c in this.children){
            if( this.parent == null )
                c.print("");
            else {
                if( lastChild )
                    c.print(prefix + "   " );
                else
                    c.print(prefix + "  " + VLINE );
            }
        }
    }

    public override string ToString(){
        if( this.token == null )
            return this.sym;
        else
            return $"{this.sym} ({this.token.lexeme})";
    }

    public void collectClassNames(){
        this.production?.pspec.collectClassNames(this);
    }

} //end TreeNode

} //end namespace lab