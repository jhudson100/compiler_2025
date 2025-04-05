namespace lab{


public abstract class VarLocation{
    public abstract void toJson(StreamWriter w);
}


public class GlobalLocation : VarLocation{
    public Label lbl;
    public GlobalLocation(Label lbl){
        this.lbl = lbl;
    }
    public override string ToString(){
        return $"global {lbl}";
    }
    public override void toJson(StreamWriter w){
        w.Write( $"{{ \"locationType\" : \"global\" }}");
    }
}

public class LocalLocation : VarLocation{
    public int num; //the number of the local (its spot on the stack)
    public string name; //for debugging, info, etc.
    public LocalLocation(int num, string name){
        this.num=num;
        this.name=name;
    }

    public override string ToString(){
        return $"local #{this.num}";
    }

    public override void toJson(StreamWriter w){
        w.Write( $"{{ \"locationType\" : \"local\", \"num\" : {this.num} }}" );
    }
}

public class ParameterLocation : VarLocation {
    public int num;
    public ParameterLocation(int num){
        this.num = num;
    }

    public override void toJson(StreamWriter w){
        w.Write( $"{{ \"locationType\" : \"parameter\", \"num\" : {this.num} }}" );
    }
    public override string ToString(){
        return $"param #{this.num}";
    }
}
     

} // namespace