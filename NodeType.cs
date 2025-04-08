using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab{
    

public abstract class NodeType {
    public readonly string friendlyName;
    public NodeType(string n){
        this.friendlyName=n;
    }
    public override string ToString(){
        return this.friendlyName;
    }

    public override bool Equals(Object o){
        NodeType v = o as NodeType;
        if( o == null )
            return false;
        return this.GetType() == o.GetType();
    }

    public static bool operator==(NodeType v1, NodeType v2){
        if( v1 is null && v2 is null )
            return true;
        if( v1 is null || v2 is null )
            return false;
        return v1.Equals(v2);
    }
    public static bool operator!=(NodeType v1, NodeType v2){
        return !(v1==v2);
    }
    public override int GetHashCode(){
        //mostly bogus
        return 42;
    }

    // NodeType.Int  <--->   new IntNodeType()
    public static readonly IntNodeType Int = new ();
    public static readonly FloatNodeType Float = new ();
    public static readonly BoolNodeType Bool = new ();
    public static readonly StringNodeType String = new ();
    public static readonly VoidNodeType Void = new ();

    public static NodeType typeFromToken(Token t){
        switch(t.lexeme){
            case "int": return NodeType.Int;
            case "float": return NodeType.Float;
            case "bool": return NodeType.Bool;
            case "string": return NodeType.String;
            default:
                throw new Exception("Internal compiler error: type from token "+t);
        }
    }
}

public class BoolNodeType : NodeType {
    public BoolNodeType(): base("bool") {}
}

public class IntNodeType : NodeType {
    public IntNodeType() : base("int") {}
}


public class FloatNodeType : NodeType {
    public FloatNodeType() : base("float") {}
}


public class StringNodeType : NodeType {
    public StringNodeType() : base("string") {}
}

public class FunctionNodeType: NodeType {
    public NodeType returnType;
    public List<NodeType> paramTypes;
    public FunctionNodeType(NodeType returnType, 
        List<NodeType> paramTypes): base("func") {
            this.returnType = returnType;
            this.paramTypes = paramTypes;
    }

    public override bool Equals(Object o){
        var f2 = o as FunctionNodeType;
        if( f2 == null )
            return false;

        throw new Exception("TBD");
    }

    public override int GetHashCode()
    {
        throw new Exception("TBD");
    }
}

public class VoidNodeType : NodeType {
    public VoidNodeType() : base("void") {}
}


public class NodeTypeJsonConverter : JsonConverter<NodeType> {

    public NodeTypeJsonConverter(){}

    public override NodeType Read( ref Utf8JsonReader r,
                                   Type toConvert,
                                   JsonSerializerOptions opts)
    {
        string s = r.GetString();
        switch(s){
            case "int": return NodeType.Int;
            case "float": return NodeType.Float;
            case "string": return NodeType.String;
            case "bool": return NodeType.Bool;
            default: throw new Exception("Unknown node type "+s);
        }
    }
    public override void Write( Utf8JsonWriter w,
        NodeType typ, JsonSerializerOptions opts )
    {
        w.WriteStringValue(typ.friendlyName);
    }
}
} //namespace
