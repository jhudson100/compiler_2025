namespace lab{


public abstract class VarLocation{

    // public abstract void toJson(StreamWriter w);

    // public static VarLocation fromJson(StreamReader r){
    //     bool notNull = Utils.expectJsonOpenBraceOrNull(r);
    //     if(notNull){
    //         string type = Utils.expectJsonString(r,"locationType");
    //         VarLocation loc;
    //         if( type == "global"){
    //             loc = new GlobalLocation();
    //         } else if( type == "local"){
    //             int num = Utils.expectJsonInt(r,"num");
    //             loc = new LocalLocation(num);
    //         } else if( type == "parameter"){
    //             int num = Utils.expectJsonInt(r,"num");
    //             loc = new ParameterLocation(num);
    //         } else {
    //             throw new Exception("Bad location type");
    //         }
    //         Utils.expectJsonCloseBrace(r);
    //         return loc;
    //     } else {
    //         return null;
    //     }
    // }

}


public class GlobalLocation : VarLocation{
    public override string ToString(){
        return "global";
    }
    // public override void toJson(StreamWriter w){
    //     w.Write( "{ \"locationType\" : \"global\" }" );
    // }
}

public class LocalLocation : VarLocation{
    public int num; //the number of the local (its spot on the stack)
    public LocalLocation(int num){
        this.num=num;
    }

    public override string ToString(){
        return $"local #{this.num}";
    }

    // public override void toJson(StreamWriter w){
    //     w.Write( $"{{ \"locationType\" : \"local\", \"num\" : {this.num} }}" );
    // }
}

public class ParameterLocation : VarLocation {
    public int num;
    public ParameterLocation(int num){
        this.num = num;
    }
    
    public override string ToString(){
        return $"param #{this.num}";
    }
     
    // public override void toJson(StreamWriter w){
    //     w.Write( $"{{ \"locationType\" : \"parameter\", \"num\" : {this.num} }}" );
    // }
}

} // namespace