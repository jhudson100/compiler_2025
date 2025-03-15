namespace lab{

public class VarInfo{
    public Token token;
    public int nestingLevel;
    public NodeType type;
    public VarLocation location;
    public VarInfo(Token t, int nl, NodeType nt, VarLocation loc){
        this.token=t;
        this.nestingLevel=nl;
        this.type=nt;
        this.location = loc;
    }

    public override string ToString(){
        string tmp = $"nesting={this.nestingLevel} type={this.type} loc={this.location}";
        return tmp;
    }
    public void toJson(StreamWriter w){
        w.Write("{");
        w.Write($"\"token\": {token},");
        w.Write($"\"nestingLevel\": {nestingLevel},");
        w.Write($"\"type\": ");
        type.toJson(w);
        w.Write(",");
        w.Write($"\"location\":");
        location.toJson(w);
        w.WriteLine("}");
    }
    public static VarInfo fromJson(StreamReader r){
        if( Utils.expectJsonOpenBraceOrNull(r) ){
            Token t = Utils.expectJsonToken(r,"token");
            int nl = Utils.expectJsonInt(r,"nestingLevel");
            NodeType nt = Utils.expectJsonNodeType(r,"type");
            VarLocation loc = Utils.expectJsonVarLocation(r,"location");
            Utils.expectJsonCloseBrace(r);
            return new VarInfo(t,nl,nt,loc);
        } else {
            return null;
        }
    }

}

} //namespace lab