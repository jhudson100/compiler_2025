namespace lab{


public abstract class VarLocation{
}


public class GlobalLocation : VarLocation{
    public override string ToString(){
        return "global";
    }
}

public class LocalLocation : VarLocation{
    public int num; //the number of the local (its spot on the stack)
    public LocalLocation(int num){
        this.num=num;
    }

    public override string ToString(){
        return $"local #{this.num}";
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
}

} // namespace