namespace lab{

public class VarInfo{
    public Token token;
    public int nestingLevel;
    public NodeType type;
    public VarLocation location;
    public VarInfo(Token token, int nesting, NodeType type, VarLocation location){
        this.token=token;
        this.nestingLevel=nesting;
        this.type=type;
        this.location=location;
    }
    public override string ToString(){
        string tmp = $"nesting:{this.nestingLevel} type:{this.type} location:{this.location}";
        return tmp;
    }        

    public void toJson(StreamWriter w){
        w.Write($"{{ \"type\": \"{this.type}\", \"nesting\": {this.nestingLevel}, \"location\":");
        this.location.toJson(w);
        w.Write("}");
    }
}

} //namespace lab