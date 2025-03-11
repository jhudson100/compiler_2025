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

    //FIXME: Add these
    // public static readonly BoolNodeType Bool = new ();
    // public static readonly StringNodeType String = new ();
    // public static readonly VoidNodeType Void = new ();

    public static NodeType tokenToNodeType(Token t){
        if( t.sym != "TYPE" )
            throw new Exception("ICE");
        switch(t.lexeme){
            case "int": return NodeType.Int;
            case "float": return NodeType.Float;
            //TODO: Finish me
            default: throw new Exception("ICE");
        }

    }
}

public class IntNodeType : NodeType {
    public IntNodeType() : base("int") {}
}

public class FloatNodeType : NodeType {
    public FloatNodeType() : base("float") {}
}




public class NodeTypeJsonConverter : JsonConverter<NodeType> {

    public NodeTypeJsonConverter(){}

    public override NodeType Read( ref Utf8JsonReader r,
                                   Type toConvert,
                                   JsonSerializerOptions opts)
    {
        throw new Exception("Not implemented");
    }
    public override void Write( Utf8JsonWriter w,
        NodeType typ, JsonSerializerOptions opts )
    {
        w.WriteStringValue(typ.friendlyName);
    }
}
} //namespace