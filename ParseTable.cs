namespace lab{
public static class ParseTable{
    public static List<Dictionary<string,ParseAction> > table = new() {
        // DFA STATE 0
        // S' :: • S ║ $
        // S :: • sum SEMI ║ $
        // sum :: • sum PLUS prod ║ SEMI PLUS
        // sum :: • prod ║ SEMI PLUS
        // prod :: • prod MUL factor ║ SEMI PLUS MUL
        // prod :: • factor ║ SEMI PLUS MUL
        // factor :: • NUM ║ SEMI PLUS MUL
        // factor :: • LPAREN sum RPAREN ║ SEMI PLUS MUL
        new Dictionary<string,ParseAction>(){
                {"S" , new ParseAction(PAction.SHIFT, 1, null, -1)},
                {"sum" , new ParseAction(PAction.SHIFT, 2, null, -1)},
                {"prod" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 6, null, -1)},
        },
        // DFA STATE 1
        // S' :: S • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 1, "S'", 7)},
        },
        // DFA STATE 2
        // S :: sum • SEMI ║ $
        // sum :: sum • PLUS prod ║ SEMI PLUS
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 13, null, -1)},
                {"PLUS" , new ParseAction(PAction.SHIFT, 9, null, -1)},
        },
        // DFA STATE 3
        // sum :: prod • ║ SEMI PLUS RPAREN
        // prod :: prod • MUL factor ║ SEMI PLUS RPAREN MUL
        new Dictionary<string,ParseAction>(){
                {"MUL" , new ParseAction(PAction.SHIFT, 11, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "sum", 2)},
                {"PLUS",new ParseAction(PAction.REDUCE, 1, "sum", 2)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "sum", 2)},
        },
        // DFA STATE 4
        // prod :: factor • ║ SEMI PLUS MUL RPAREN
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "prod", 4)},
                {"PLUS",new ParseAction(PAction.REDUCE, 1, "prod", 4)},
                {"MUL",new ParseAction(PAction.REDUCE, 1, "prod", 4)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "prod", 4)},
        },
        // DFA STATE 5
        // factor :: NUM • ║ SEMI PLUS MUL RPAREN
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "factor", 5)},
                {"PLUS",new ParseAction(PAction.REDUCE, 1, "factor", 5)},
                {"MUL",new ParseAction(PAction.REDUCE, 1, "factor", 5)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 5)},
        },
        // DFA STATE 6
        // factor :: LPAREN • sum RPAREN ║ SEMI PLUS MUL RPAREN
        // sum :: • sum PLUS prod ║ RPAREN PLUS
        // sum :: • prod ║ RPAREN PLUS
        // prod :: • prod MUL factor ║ RPAREN PLUS MUL
        // prod :: • factor ║ RPAREN PLUS MUL
        // factor :: • NUM ║ RPAREN PLUS MUL
        // factor :: • LPAREN sum RPAREN ║ RPAREN PLUS MUL
        new Dictionary<string,ParseAction>(){
                {"sum" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"prod" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 6, null, -1)},
        },
        // DFA STATE 7
        // factor :: LPAREN sum • RPAREN ║ SEMI PLUS MUL RPAREN
        // sum :: sum • PLUS prod ║ RPAREN PLUS
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 8, null, -1)},
                {"PLUS" , new ParseAction(PAction.SHIFT, 9, null, -1)},
        },
        // DFA STATE 8
        // factor :: LPAREN sum RPAREN • ║ SEMI PLUS MUL RPAREN
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "factor", 6)},
                {"PLUS",new ParseAction(PAction.REDUCE, 3, "factor", 6)},
                {"MUL",new ParseAction(PAction.REDUCE, 3, "factor", 6)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "factor", 6)},
        },
        // DFA STATE 9
        // sum :: sum PLUS • prod ║ SEMI RPAREN PLUS
        // prod :: • prod MUL factor ║ SEMI RPAREN MUL PLUS
        // prod :: • factor ║ SEMI RPAREN MUL PLUS
        // factor :: • NUM ║ SEMI RPAREN MUL PLUS
        // factor :: • LPAREN sum RPAREN ║ SEMI RPAREN MUL PLUS
        new Dictionary<string,ParseAction>(){
                {"prod" , new ParseAction(PAction.SHIFT, 10, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 6, null, -1)},
        },
        // DFA STATE 10
        // sum :: sum PLUS prod • ║ SEMI RPAREN PLUS
        // prod :: prod • MUL factor ║ SEMI RPAREN MUL PLUS
        new Dictionary<string,ParseAction>(){
                {"MUL" , new ParseAction(PAction.SHIFT, 11, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "sum", 1)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "sum", 1)},
                {"PLUS",new ParseAction(PAction.REDUCE, 3, "sum", 1)},
        },
        // DFA STATE 11
        // prod :: prod MUL • factor ║ SEMI PLUS RPAREN MUL
        // factor :: • NUM ║ SEMI PLUS RPAREN MUL
        // factor :: • LPAREN sum RPAREN ║ SEMI PLUS RPAREN MUL
        new Dictionary<string,ParseAction>(){
                {"factor" , new ParseAction(PAction.SHIFT, 12, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 6, null, -1)},
        },
        // DFA STATE 12
        // prod :: prod MUL factor • ║ SEMI PLUS RPAREN MUL
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "prod", 3)},
                {"PLUS",new ParseAction(PAction.REDUCE, 3, "prod", 3)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "prod", 3)},
                {"MUL",new ParseAction(PAction.REDUCE, 3, "prod", 3)},
        },
        // DFA STATE 13
        // S :: sum SEMI • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 2, "S", 0)},
        },
    }; //close the table initializer
} //close the ParseTable class
} //close the namespace lab thing
