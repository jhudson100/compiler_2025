namespace lab {

public class OpSubIndirect: Opcode {
    IntRegister op1;
    int offset;
    int constant;
    string comment;

    public OpSubIndirect( IntRegister op1, int offset, int constant, string comment=""){
        this.op1=op1;
        this.offset=offset;
        this.constant=constant;
        this.comment=comment;
    }

    public override void output(StreamWriter w){
        string comment = this.comment;
        if(comment.Length > 0 ){
            comment = "/* " + comment +" */";
        }
        w.WriteLine($"    subq ${this.constant}, {this.offset}({this.op1})    {comment}");
    }

    public override bool touchesStack()
    {
        return true;        //we don't know where the register points
    }
}

}