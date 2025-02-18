namespace lab{

public enum PAction {
    SHIFT, REDUCE
}
public class ParseAction{
    public PAction action;
    public int num;        //shift: the new state 
                    //  that we are going to
                    //reduce: length of rhs (num to pop)
    public string sym;     //shift: unused
                    //reduce: lhs symbol that I'm reducing
                    //to
    public ParseAction( PAction action, int num, string sym){
        this.action=action;
        this.num=num;
        this.sym=sym;
    }
}


}   
