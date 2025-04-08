namespace lab{
    
public abstract class VarLocation{
    public abstract void pushAddressToStack(IntRegister temporary);
    public abstract void pushValueToStack(IntRegister temp1,
                                          IntRegister temp2);
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
        w.Write("{ \"storageClass\": \"global\" }");
    }

    public override void pushAddressToStack(IntRegister temporary){
        throw new Exception();
    }

    public override void pushValueToStack(IntRegister temp1, IntRegister temp2)
    {
        //get address of the global to temp1
        Asm.add( new OpMov( lbl, temp1 ));
        //dereference that address to get storage class to temp2
        Asm.add( new OpMov( temp1, 0, temp2));
        //dereference that address to get value to temp1
        Asm.add( new OpMov( temp1, 8, temp1));
        //push value and storage class
        Asm.add( new OpPush( temp1, temp2));
    }
}

public class LocalLocation : VarLocation{
    public int num;
    public string name; //for debugging, info, etc.
    public LocalLocation(int num, string name){
        this.num=num;
        this.name=name;
    }

    public override void toJson(StreamWriter w){
        w.Write($"{{ \"storageClass\": \"local\", \"index\": {this.num} }}");
    }
    public override string ToString(){
        return $"local #{this.num}";
    }

    public override void pushAddressToStack(IntRegister temporary){
        //compute rbp - ( (i+1) * 16)  where i is the number of the local
        //that value is the address of the storage class of local i
        int offset = (num+1)*16;
        //lea = load effective address
        // lea offset(%rbp), %rax  ----> compute rbp+offset and store to rax
        Asm.add( new OpLea( Register.rbx, -offset, temporary, name ));

        //an address is always a primitive object
        Asm.add( new OpPush( temporary, StorageClass.PRIMITIVE));

    }

    public override void pushValueToStack(IntRegister temp1, IntRegister temp2)
    {
        throw new NotImplementedException();
    }


}


public class ParameterLocation : VarLocation {
    public int num;
    public ParameterLocation(int num){
        this.num = num;
    }

    public override void pushAddressToStack(IntRegister temporary)
    {
        throw new NotImplementedException();
    }

    public override void pushValueToStack(IntRegister temp1, IntRegister temp2)
    {
        throw new NotImplementedException();
    }

    public override string ToString(){
        return $"param #{this.num}";
    }

    public override void toJson(StreamWriter w){
        w.Write($"{{ \"storageClass\": \"parameter\", \"index\": {this.num} }}");
    }
}


} //namespace lab