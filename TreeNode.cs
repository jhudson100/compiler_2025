using System.Text.Json.Serialization;

namespace lab{

public class TreeNode{
    public string sym;  //terminal name or nonterminal
                        //"NUM", "cond"
    public Token token; //only meaningful for terminals

    public List<TreeNode> children = new();

    public int productionNumber;

    [JsonIgnore()]
    public TreeNode parent = null;


  
    //only meaningful for tree nodes that are ID's and
    //which are variables
    public VarInfo varInfo = null;


    //only meaningful for loop nodes; otherwise they are null
    public Label entry=null;
    public Label exit=null;
    public Label test=null;

    [JsonConverter(typeof(NodeTypeJsonConverter))]
    public NodeType nodeType = null;


    public TreeNode this[string childSym] {
        get {
            foreach( var c in this.children ){
                if( c.sym == childSym ){
                    return c;
                }
            }
            throw new Exception("No such child");
        }
    }


    Production production {
        get {
            if( this.productionNumber >= 0 )
                return Grammar.productions[this.productionNumber];
            return null;
        }
    }

    //this is here for json deserialization
    public TreeNode(){}

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

    public void prependChild(TreeNode n){
        this.children.Insert(0,n);
        n.parent=this;
    }

    public void setParents(){
        foreach(var c in this.children){
            c.parent=this;
            c.setParents();
        }
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
        string tmp=this.sym;
        
        if( this.token != null )
            tmp += $" ({this.token.lexeme})";

        if( this.nodeType != null )
            tmp += " nodeType="+this.nodeType.ToString();

        return tmp;
    }

    public void removeUnitProductions(){

        for(int i=0;i<this.children.Count;++i)
            this.children[i].removeUnitProductions();

        if( this.children.Count == 1 && this.parent != null){
            this.parent.replaceChild(this, this.children[0] );
        }
    }

    public void replaceChild( TreeNode n, TreeNode c){
        //replace child n with c
        for(int i=0;i<this.children.Count;++i){
            if( this.children[i] == n ){
                this.children[i] = c;
                c.parent=this;
                n.parent=null;
                return;
            }
        }
        throw new Exception();
    }

    public void collectClassNames(){
        this.production?.pspec.collectClassNames(this);
    }

    public void collectFunctionNames(){
        this.production?.pspec.collectFunctionNames(this);
    }

    public void setNodeTypes(){
        this.production?.pspec.setNodeTypes(this);
    }

    public void generateCode(){
        this.production?.pspec.generateCode(this);
    }
} //end TreeNode

} //end namespace lab
