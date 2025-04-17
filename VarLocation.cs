namespace lab{


public abstract class VarLocation{
    public abstract void toJson(StreamWriter w);
    public abstract void pushAddressToStack(IntRegister temporary);
    public abstract void pushValueToStack(IntRegister temp1,
                                          IntRegister temp2);
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
    public override void pushAddressToStack(IntRegister temp1){
        //get address of the global to temp1
        Asm.add( new OpMov( lbl, temp1 ));
        Asm.add( new OpPush(temp1, StorageClass.PRIMITIVE) );
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

    public override void pushAddressToStack(IntRegister temporary){
        //compute rbp - ( (i+1) * 16)  where i is the number of the local
        //that value is the address of the storage class of local i
        int offset = (num+1)*16;
        //lea = load effective address
        // lea offset(%rbp), %rax  ----> compute rbp+offset and store to rax
        Asm.add( new OpLea( Register.rbp, -offset, temporary, name ));

        //an address is always a primitive object
        Asm.add( new OpPush( temporary, StorageClass.PRIMITIVE));
    }

    public override void pushValueToStack(IntRegister temp1, IntRegister temp2)
    {
        //compute rbp - ( (i+1) * 16)  where i is the number of the local
        //that value is the address of the storage class of local i
        int offset = (num+1)*16;
        //lea = load effective address
        // lea offset(%rbp), %rax  ----> compute rbp+offset and store to rax
        Asm.add( new OpLea( Register.rbp, -offset, temp1, name ));
        Asm.add( new OpMov( temp1,0, temp2 ));
        Asm.add( new OpMov( temp1,8, temp1 ));
        Asm.add( new OpPush( temp1, temp2) );
    }

}

public class ParameterLocation : VarLocation {
    public int num;
    public string name;

    public ParameterLocation(int num, string name){
        this.num = num;
        this.name=name;
    }

    public override void pushAddressToStack(IntRegister temporary){
        throw new NotImplementedException();
    }

    public override void pushValueToStack(IntRegister temp1, IntRegister temp2){


        //compute rbp + ( (i+1) * 16)  where i is the number of the parameter
        //that value is the address of the storage class of local i
        int offset = (num+1)*16;

        //lea = load effective address
        // register temp1 holds the address where this parameter variable
        //lives in memory
        Asm.add( new OpLea( Register.rbp, offset, temp1, name ));

        //load storage class of variable into temp2
        Asm.add( new OpMov( temp1, 0, temp2));

        //load value of variable into temp1
        Asm.add( new OpMov( temp1, 8, temp1));

        //push value then push storage class
        Asm.add( new OpPush( temp1, temp2));

    }

    public override void toJson(StreamWriter w){
        w.Write( $"{{ \"locationType\" : \"parameter\", \"num\" : {this.num} }}" );
    }
    public override string ToString(){
        return $"param #{this.num}";
    }
}
     

} // namespace