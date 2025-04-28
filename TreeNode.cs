using System.Text.Json.Serialization;

namespace lab{

public class TreeNode{
    public string sym;  //terminal name or nonterminal
                        //"NUM", "cond"
    public Token token; //only meaningful for terminals

    public List<TreeNode> children = new();

    public int productionNumber;

    [JsonIgnore]
    public TreeNode parent = null;

    [JsonConverter(typeof(NodeTypeJsonConverter))]
    public NodeType nodeType = null;

    public VarInfo varInfo = null;

    //for loop nodes
    public Label loopTest;
    public Label loopExit;

    //only meaningful for fundecl nodes: Number of locals
    //declared in that function
    public int numLocals = -1;

    //true if we can prove this node executes a return statement
    public bool returns=false;

    //only for funcdecl nodes
    public NodeType[] localVarTypes;
    public string[] localVarNames;

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
        n.parent = this;
        this.children.Insert(0,n);
    }

    

    public void toJson(StreamWriter w, string prefix=""){
        string prefix0=prefix;
        prefix += "  ";
        w.WriteLine(prefix0+"{");
        w.WriteLine( prefix+$"\"sym\" : \"{this.sym}\",");
        w.Write( prefix+$"\"token\" : ");
        if( this.token != null )
            this.token.toJson(w);
        else
            w.Write("null");
        w.WriteLine(",");

        // w.WriteLine(prefix+$"\"productionNumber\" : \"{this.productionNumber}\",");

        //node type string
        string nts = ( this.nodeType == null ? "null" : $"\"{this.nodeType}\"" );

        w.WriteLine(prefix+$"\"nodeType\": {nts},");

        w.Write(prefix+$"\"varInfo\": ");
        if( this.varInfo == null )
            w.Write("null");
        else
            this.varInfo.toJson(w);
        w.WriteLine(",");

        if( this.children.Count == 0 ){
            w.WriteLine( prefix+"\"children\": []");
        } else {
            w.WriteLine( prefix+"\"children\": [");
            string prefix2=prefix+"  ";
            for(int i=0;i<this.children.Count;i++){
                this.children[i].toJson(w,prefix2);
                if( i != this.children.Count-1)
                    w.WriteLine(prefix2+",");
            }
            w.WriteLine(prefix+"]");
        }
        w.WriteLine(prefix0+"}");
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
        string s = $"{this.sym}";
        if( this.token != null )
            s += $" ({this.token.lexeme})";
        if( this.nodeType != null )
            s += $" {this.nodeType}";
        if( this.varInfo != null )
            s += $" varInfo[{this.varInfo}]";
        return s;
    }


    public void removeUnitProductions(){
        for(int i=0;i<this.children.Count;++i)
            this.children[i].removeUnitProductions();

        if( this.children.Count == 1 && this.parent != null){
            this.parent.replaceChild(this, this.children[0] );
        }
    }

    public void replaceChild( TreeNode n, TreeNode c){
        for(int i=0;i<this.children.Count;++i){
            if( this.children[i] == n ){
                this.children[i] = c;
                c.parent=this;
                n.parent=null;
                return;
            }
        }
        throw new Exception("No such child");
    }

    public Token firstToken(){
        if( this.token != null)
            return this.token;
        foreach(var c in this.children){
            Token t = c.firstToken();
            if(t!=null)
                return t;
        }
        return null;
    }
    public Token lastToken(){
        if( this.token != null)
            return this.token;
        for(int i=this.children.Count-1;i>=0;i--){
            Token t = this.children[i].lastToken();
            if(t!=null)
                return t;
        }
        return null;
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


    public void returnCheck(){
        this.production?.pspec.returnCheck(this);
    }

    public void pushAddressToStack(){
        if( this.production != null )
            this.production.pspec.pushAddressToStack(this);
        else
            Utils.error(this.firstToken(),"Cannot get address");
    }

} //end TreeNode

} //end namespace lab