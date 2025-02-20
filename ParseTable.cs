namespace lab{
public static class ParseTable{
    public static List<Dictionary<string,ParseAction> > table = new() {
        // DFA STATE 0
        new Dictionary<string,ParseAction>(){
            // S' :: S
            {"$",new ParseAction(PAction.REDUCE, 1, "S'", 245634465)},
        }
    }; //close the table initializer
} //close the ParseTable class
} //close the namespace lab thing
