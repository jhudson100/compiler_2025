namespace lab{

public enum PAction {
    SHIFT, REDUCE
}
public class ParseAction{
    public PAction action;  //shift or reduce

    public int num;        //shift: the new state 
                    //  that we are going to
                    //reduce: length of rhs (num to pop)

    public string sym;     //shift: unused
                    //reduce: lhs symbol that I'm reducing
                    //to

    public int productionNumber;    //for reduce: The index of the
                                    //production that we are using

    public ParseAction( PAction action, int num, string sym, int productionNumber){
        this.action=action;
        this.num=num;
        this.sym=sym;
        this.productionNumber=productionNumber;
    }
}


}   
