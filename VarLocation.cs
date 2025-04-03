namespace lab{
    
public abstract class VarLocation{
    public abstract void toJson(StreamWriter w);
}


public class GlobalLocation : VarLocation{
    public override string ToString(){
        return "global";
    }
    public override void toJson(StreamWriter w){
        w.Write("{ \"storageClass\": \"global\" }");
    }
}

public class LocalLocation : VarLocation{
    public int num;
    public LocalLocation(int num){
        this.num=num;
    }

    public override string ToString(){
        return $"local #{this.num}";
    }

    public override void toJson(StreamWriter w){
        w.Write($"{{ \"storageClass\": \"local\", \"index\": {this.num} }}");
    }

}


public class ParameterLocation : VarLocation {
    public int num;
    public ParameterLocation(int num){
        this.num = num;
    }
        public override string ToString(){
        return $"param #{this.num}";
    }

    public override void toJson(StreamWriter w){
        w.Write($"{{ \"storageClass\": \"parameter\", \"index\": {this.num} }}");
    }
}

} //namespace lab