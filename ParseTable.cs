namespace lab{
public static class ParseTable{
    public static List<Dictionary<string,ParseAction> > table = new() {
        // DFA STATE 0
        // S' :: • S ║ $
        // S :: • decls ║ $
        // decls :: • funcdecl decls ║ $
        // decls :: • classdecl decls ║ $
        // decls :: • vardecl decls ║ $
        // decls :: • SEMI decls ║ $
        // decls :: • ║ $
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // classdecl :: • CLASS ID LBRACE memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"S" , new ParseAction(PAction.SHIFT, 1, null, -1)},
                {"decls" , new ParseAction(PAction.SHIFT, 2, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"classdecl" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 6, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"CLASS" , new ParseAction(PAction.SHIFT, 8, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"$",new ParseAction(PAction.REDUCE, 0, "decls", 5)},
        },
        // DFA STATE 1
        // S' :: S • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 1, "S'", 82)},
        },
        // DFA STATE 2
        // S :: decls • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 1, "S", 0)},
        },
        // DFA STATE 3
        // decls :: funcdecl • decls ║ $
        // decls :: • funcdecl decls ║ $
        // decls :: • classdecl decls ║ $
        // decls :: • vardecl decls ║ $
        // decls :: • SEMI decls ║ $
        // decls :: • ║ $
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // classdecl :: • CLASS ID LBRACE memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"decls" , new ParseAction(PAction.SHIFT, 149, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"classdecl" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 6, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"CLASS" , new ParseAction(PAction.SHIFT, 8, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"$",new ParseAction(PAction.REDUCE, 0, "decls", 5)},
        },
        // DFA STATE 4
        // decls :: classdecl • decls ║ $
        // decls :: • funcdecl decls ║ $
        // decls :: • classdecl decls ║ $
        // decls :: • vardecl decls ║ $
        // decls :: • SEMI decls ║ $
        // decls :: • ║ $
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // classdecl :: • CLASS ID LBRACE memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"decls" , new ParseAction(PAction.SHIFT, 148, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"classdecl" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 6, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"CLASS" , new ParseAction(PAction.SHIFT, 8, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"$",new ParseAction(PAction.REDUCE, 0, "decls", 5)},
        },
        // DFA STATE 5
        // decls :: vardecl • decls ║ $
        // decls :: • funcdecl decls ║ $
        // decls :: • classdecl decls ║ $
        // decls :: • vardecl decls ║ $
        // decls :: • SEMI decls ║ $
        // decls :: • ║ $
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // classdecl :: • CLASS ID LBRACE memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"decls" , new ParseAction(PAction.SHIFT, 147, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"classdecl" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 6, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"CLASS" , new ParseAction(PAction.SHIFT, 8, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"$",new ParseAction(PAction.REDUCE, 0, "decls", 5)},
        },
        // DFA STATE 6
        // decls :: SEMI • decls ║ $
        // decls :: • funcdecl decls ║ $
        // decls :: • classdecl decls ║ $
        // decls :: • vardecl decls ║ $
        // decls :: • SEMI decls ║ $
        // decls :: • ║ $
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // classdecl :: • CLASS ID LBRACE memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"decls" , new ParseAction(PAction.SHIFT, 146, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 3, null, -1)},
                {"classdecl" , new ParseAction(PAction.SHIFT, 4, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 5, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 6, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"CLASS" , new ParseAction(PAction.SHIFT, 8, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"$",new ParseAction(PAction.REDUCE, 0, "decls", 5)},
        },
        // DFA STATE 7
        // funcdecl :: FUNC • ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        new Dictionary<string,ParseAction>(){
                {"ID" , new ParseAction(PAction.SHIFT, 93, null, -1)},
        },
        // DFA STATE 8
        // classdecl :: CLASS • ID LBRACE memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"ID" , new ParseAction(PAction.SHIFT, 76, null, -1)},
        },
        // DFA STATE 9
        // vardecl :: VAR • ID COLON TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR • ID COLON TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR • ID COLON ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR • ID COLON ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"ID" , new ParseAction(PAction.SHIFT, 10, null, -1)},
        },
        // DFA STATE 10
        // vardecl :: VAR ID • COLON TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID • COLON TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID • COLON ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID • COLON ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"COLON" , new ParseAction(PAction.SHIFT, 11, null, -1)},
        },
        // DFA STATE 11
        // vardecl :: VAR ID COLON • TYPE ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID COLON • TYPE EQ expr ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID COLON • ID ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID COLON • ID EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"TYPE" , new ParseAction(PAction.SHIFT, 12, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 13, null, -1)},
        },
        // DFA STATE 12
        // vardecl :: VAR ID COLON TYPE • ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID COLON TYPE • EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"EQ" , new ParseAction(PAction.SHIFT, 74, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 4, "vardecl", 39)},
                {"FUNC",new ParseAction(PAction.REDUCE, 4, "vardecl", 39)},
                {"CLASS",new ParseAction(PAction.REDUCE, 4, "vardecl", 39)},
                {"VAR",new ParseAction(PAction.REDUCE, 4, "vardecl", 39)},
                {"$",new ParseAction(PAction.REDUCE, 4, "vardecl", 39)},
        },
        // DFA STATE 13
        // vardecl :: VAR ID COLON ID • ║ SEMI FUNC CLASS VAR $
        // vardecl :: VAR ID COLON ID • EQ expr ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"EQ" , new ParseAction(PAction.SHIFT, 14, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 4, "vardecl", 41)},
                {"FUNC",new ParseAction(PAction.REDUCE, 4, "vardecl", 41)},
                {"CLASS",new ParseAction(PAction.REDUCE, 4, "vardecl", 41)},
                {"VAR",new ParseAction(PAction.REDUCE, 4, "vardecl", 41)},
                {"$",new ParseAction(PAction.REDUCE, 4, "vardecl", 41)},
        },
        // DFA STATE 14
        // vardecl :: VAR ID COLON ID EQ • expr ║ SEMI FUNC CLASS VAR $
        // expr :: • orexp ║ SEMI FUNC CLASS VAR $
        // orexp :: • orexp OROP andexp ║ SEMI FUNC CLASS VAR $ OROP
        // orexp :: • andexp ║ SEMI FUNC CLASS VAR $ OROP
        // andexp :: • andexp ANDOP relexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // andexp :: • relexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // relexp :: • bitexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 15, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 15
        // vardecl :: VAR ID COLON ID EQ expr • ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 6, "vardecl", 42)},
                {"FUNC",new ParseAction(PAction.REDUCE, 6, "vardecl", 42)},
                {"CLASS",new ParseAction(PAction.REDUCE, 6, "vardecl", 42)},
                {"VAR",new ParseAction(PAction.REDUCE, 6, "vardecl", 42)},
                {"$",new ParseAction(PAction.REDUCE, 6, "vardecl", 42)},
        },
        // DFA STATE 16
        // expr :: orexp • ║ SEMI FUNC CLASS VAR $ RPAREN RBRACKET COMMA EQ
        // orexp :: orexp • OROP andexp ║ SEMI FUNC CLASS VAR $ RPAREN RBRACKET COMMA EQ OROP
        new Dictionary<string,ParseAction>(){
                {"OROP" , new ParseAction(PAction.SHIFT, 72, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"$",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "expr", 43)},
        },
        // DFA STATE 17
        // orexp :: andexp • ║ SEMI FUNC CLASS VAR $ OROP RPAREN RBRACKET COMMA EQ
        // andexp :: andexp • ANDOP relexp ║ SEMI FUNC CLASS VAR $ OROP RPAREN RBRACKET COMMA EQ ANDOP
        new Dictionary<string,ParseAction>(){
                {"ANDOP" , new ParseAction(PAction.SHIFT, 70, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"$",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "orexp", 45)},
        },
        // DFA STATE 18
        // andexp :: relexp • ║ SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"$",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "andexp", 47)},
        },
        // DFA STATE 19
        // relexp :: bitexp • RELOP bitexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ
        // relexp :: bitexp • ║ SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ
        // bitexp :: bitexp • BITOP shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ BITOP
        new Dictionary<string,ParseAction>(){
                {"RELOP" , new ParseAction(PAction.SHIFT, 66, null, -1)},
                {"BITOP" , new ParseAction(PAction.SHIFT, 67, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"$",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "relexp", 49)},
        },
        // DFA STATE 20
        // bitexp :: shiftexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP RPAREN RBRACKET COMMA EQ
        // shiftexp :: shiftexp • SHIFTOP sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP RPAREN RBRACKET COMMA EQ SHIFTOP
        new Dictionary<string,ParseAction>(){
                {"SHIFTOP" , new ParseAction(PAction.SHIFT, 64, null, -1)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"$",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "bitexp", 51)},
        },
        // DFA STATE 21
        // shiftexp :: sumexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ
        // sumexp :: sumexp • ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ ADDOP
        new Dictionary<string,ParseAction>(){
                {"ADDOP" , new ParseAction(PAction.SHIFT, 62, null, -1)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"$",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "shiftexp", 53)},
        },
        // DFA STATE 22
        // sumexp :: prodexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ
        // prodexp :: prodexp • MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        new Dictionary<string,ParseAction>(){
                {"MULOP" , new ParseAction(PAction.SHIFT, 60, null, -1)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"$",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "sumexp", 55)},
        },
        // DFA STATE 23
        // prodexp :: powexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"$",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "prodexp", 57)},
        },
        // DFA STATE 24
        // powexp :: unaryexp • POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // powexp :: unaryexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP" , new ParseAction(PAction.SHIFT, 58, null, -1)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"$",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "powexp", 59)},
        },
        // DFA STATE 25
        // unaryexp :: BITNOTOP • unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"unaryexp" , new ParseAction(PAction.SHIFT, 57, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 26
        // unaryexp :: ADDOP • unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"unaryexp" , new ParseAction(PAction.SHIFT, 56, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 27
        // unaryexp :: NOTOP • unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"unaryexp" , new ParseAction(PAction.SHIFT, 55, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 28
        // unaryexp :: preincexp • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"$",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "unaryexp", 63)},
        },
        // DFA STATE 29
        // preincexp :: PLUSPLUS • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"preincexp" , new ParseAction(PAction.SHIFT, 54, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 30
        // preincexp :: postincexp • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // postincexp :: postincexp • PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ PLUSPLUS
        new Dictionary<string,ParseAction>(){
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 53, null, -1)},
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"$",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "preincexp", 65)},
        },
        // DFA STATE 31
        // postincexp :: amfexp • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // amfexp :: amfexp • DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        // amfexp :: amfexp • LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT RPAREN RBRACKET COMMA EQ LBRACKET LPAREN
        // amfexp :: amfexp • LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET RPAREN RBRACKET COMMA EQ LPAREN
        new Dictionary<string,ParseAction>(){
                {"DOT" , new ParseAction(PAction.SHIFT, 41, null, -1)},
                {"LBRACKET" , new ParseAction(PAction.SHIFT, 42, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 43, null, -1)},
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"$",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "postincexp", 67)},
        },
        // DFA STATE 32
        // amfexp :: factor • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"$",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"DOT",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "amfexp", 71)},
        },
        // DFA STATE 33
        // factor :: NUM • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"$",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"DOT",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "factor", 72)},
        },
        // DFA STATE 34
        // factor :: LPAREN • expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // expr :: • orexp ║ RPAREN
        // orexp :: • orexp OROP andexp ║ RPAREN OROP
        // orexp :: • andexp ║ RPAREN OROP
        // andexp :: • andexp ANDOP relexp ║ RPAREN OROP ANDOP
        // andexp :: • relexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp ║ RPAREN OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 39, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 35
        // factor :: ID • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"$",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"DOT",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "factor", 74)},
        },
        // DFA STATE 36
        // factor :: FNUM • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"$",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"DOT",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "factor", 75)},
        },
        // DFA STATE 37
        // factor :: STRINGCONST • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"$",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"DOT",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "factor", 76)},
        },
        // DFA STATE 38
        // factor :: BOOLCONST • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"RELOP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"CLASS",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"$",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"OROP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"BITOP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"MULOP",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"DOT",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
                {"EQ",new ParseAction(PAction.REDUCE, 1, "factor", 77)},
        },
        // DFA STATE 39
        // factor :: LPAREN expr • RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 40, null, -1)},
        },
        // DFA STATE 40
        // factor :: LPAREN expr RPAREN • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"RELOP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"$",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"BITOP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"MULOP",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"DOT",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "factor", 73)},
        },
        // DFA STATE 41
        // amfexp :: amfexp DOT • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"factor" , new ParseAction(PAction.SHIFT, 52, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 42
        // amfexp :: amfexp LBRACKET • expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT RPAREN RBRACKET COMMA EQ LBRACKET LPAREN
        // expr :: • orexp ║ RBRACKET
        // orexp :: • orexp OROP andexp ║ RBRACKET OROP
        // orexp :: • andexp ║ RBRACKET OROP
        // andexp :: • andexp ANDOP relexp ║ RBRACKET OROP ANDOP
        // andexp :: • relexp ║ RBRACKET OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ RBRACKET OROP ANDOP
        // relexp :: • bitexp ║ RBRACKET OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP RBRACKET OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP RBRACKET OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP RBRACKET OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 50, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 43
        // amfexp :: amfexp LPAREN • calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET RPAREN RBRACKET COMMA EQ LPAREN
        // calllist :: • ║ RPAREN
        // calllist :: • calllist2 COMMA expr ║ RPAREN
        // calllist2 :: • expr ║ COMMA
        // calllist2 :: • calllist2 COMMA expr ║ COMMA
        // expr :: • orexp ║ COMMA
        // orexp :: • orexp OROP andexp ║ COMMA OROP
        // orexp :: • andexp ║ COMMA OROP
        // andexp :: • andexp ANDOP relexp ║ COMMA OROP ANDOP
        // andexp :: • relexp ║ COMMA OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ COMMA OROP ANDOP
        // relexp :: • bitexp ║ COMMA OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP COMMA OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP COMMA OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"calllist" , new ParseAction(PAction.SHIFT, 44, null, -1)},
                {"calllist2" , new ParseAction(PAction.SHIFT, 45, null, -1)},
                {"expr" , new ParseAction(PAction.SHIFT, 46, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 0, "calllist", 78)},
        },
        // DFA STATE 44
        // amfexp :: amfexp LPAREN calllist • RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET RPAREN RBRACKET COMMA EQ LPAREN
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 49, null, -1)},
        },
        // DFA STATE 45
        // calllist :: calllist2 • COMMA expr ║ RPAREN
        // calllist2 :: calllist2 • COMMA expr ║ COMMA
        new Dictionary<string,ParseAction>(){
                {"COMMA" , new ParseAction(PAction.SHIFT, 47, null, -1)},
        },
        // DFA STATE 46
        // calllist2 :: expr • ║ COMMA
        new Dictionary<string,ParseAction>(){
                {"COMMA",new ParseAction(PAction.REDUCE, 1, "calllist2", 80)},
        },
        // DFA STATE 47
        // calllist :: calllist2 COMMA • expr ║ RPAREN
        // calllist2 :: calllist2 COMMA • expr ║ COMMA
        // expr :: • orexp ║ RPAREN COMMA
        // orexp :: • orexp OROP andexp ║ RPAREN COMMA OROP
        // orexp :: • andexp ║ RPAREN COMMA OROP
        // andexp :: • andexp ANDOP relexp ║ RPAREN COMMA OROP ANDOP
        // andexp :: • relexp ║ RPAREN COMMA OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ RPAREN COMMA OROP ANDOP
        // relexp :: • bitexp ║ RPAREN COMMA OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP RPAREN COMMA OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 48, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 48
        // calllist :: calllist2 COMMA expr • ║ RPAREN
        // calllist2 :: calllist2 COMMA expr • ║ COMMA
        new Dictionary<string,ParseAction>(){
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "calllist", 79)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "calllist2", 81)},
        },
        // DFA STATE 49
        // amfexp :: amfexp LPAREN calllist RPAREN • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET RPAREN RBRACKET COMMA EQ LPAREN
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"RELOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"SEMI",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"FUNC",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"CLASS",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"VAR",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"$",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"OROP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"BITOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"MULOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"DOT",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"COMMA",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"EQ",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 4, "amfexp", 70)},
        },
        // DFA STATE 50
        // amfexp :: amfexp LBRACKET expr • RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT RPAREN RBRACKET COMMA EQ LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"RBRACKET" , new ParseAction(PAction.SHIFT, 51, null, -1)},
        },
        // DFA STATE 51
        // amfexp :: amfexp LBRACKET expr RBRACKET • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT RPAREN RBRACKET COMMA EQ LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"RELOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"SEMI",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"FUNC",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"CLASS",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"VAR",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"$",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"OROP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"BITOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"MULOP",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"DOT",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"COMMA",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"EQ",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 4, "amfexp", 69)},
        },
        // DFA STATE 52
        // amfexp :: amfexp DOT factor • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"RELOP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"$",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"BITOP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"MULOP",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"DOT",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"LBRACKET",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
                {"LPAREN",new ParseAction(PAction.REDUCE, 3, "amfexp", 68)},
        },
        // DFA STATE 53
        // postincexp :: postincexp PLUSPLUS • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ PLUSPLUS
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"RELOP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"SEMI",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"FUNC",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"CLASS",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"VAR",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"$",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"OROP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"BITOP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"MULOP",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"COMMA",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"EQ",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
                {"PLUSPLUS",new ParseAction(PAction.REDUCE, 2, "postincexp", 66)},
        },
        // DFA STATE 54
        // preincexp :: PLUSPLUS preincexp • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"RELOP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"SEMI",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"FUNC",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"CLASS",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"VAR",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"$",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"OROP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"BITOP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"MULOP",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"COMMA",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
                {"EQ",new ParseAction(PAction.REDUCE, 2, "preincexp", 64)},
        },
        // DFA STATE 55
        // unaryexp :: NOTOP unaryexp • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"RELOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"SEMI",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"FUNC",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"CLASS",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"VAR",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"$",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"OROP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"BITOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"MULOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"COMMA",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
                {"EQ",new ParseAction(PAction.REDUCE, 2, "unaryexp", 62)},
        },
        // DFA STATE 56
        // unaryexp :: ADDOP unaryexp • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"RELOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"SEMI",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"FUNC",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"CLASS",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"VAR",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"$",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"OROP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"BITOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"MULOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"COMMA",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
                {"EQ",new ParseAction(PAction.REDUCE, 2, "unaryexp", 61)},
        },
        // DFA STATE 57
        // unaryexp :: BITNOTOP unaryexp • ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"POWOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"RELOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"SEMI",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"FUNC",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"CLASS",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"VAR",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"$",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"OROP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"BITOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"MULOP",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"COMMA",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
                {"EQ",new ParseAction(PAction.REDUCE, 2, "unaryexp", 60)},
        },
        // DFA STATE 58
        // powexp :: unaryexp POWOP • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"powexp" , new ParseAction(PAction.SHIFT, 59, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 59
        // powexp :: unaryexp POWOP powexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"RELOP",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"$",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"BITOP",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"MULOP",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "powexp", 58)},
        },
        // DFA STATE 60
        // prodexp :: prodexp MULOP • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS RPAREN RBRACKET COMMA EQ MULOP
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS RPAREN RBRACKET COMMA EQ MULOP
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ MULOP
        new Dictionary<string,ParseAction>(){
                {"powexp" , new ParseAction(PAction.SHIFT, 61, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 61
        // prodexp :: prodexp MULOP powexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ MULOP
        new Dictionary<string,ParseAction>(){
                {"RELOP",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"$",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"BITOP",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
                {"MULOP",new ParseAction(PAction.REDUCE, 3, "prodexp", 56)},
        },
        // DFA STATE 62
        // sumexp :: sumexp ADDOP • prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // prodexp :: • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ ADDOP
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ ADDOP
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ADDOP
        new Dictionary<string,ParseAction>(){
                {"prodexp" , new ParseAction(PAction.SHIFT, 63, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 63
        // sumexp :: sumexp ADDOP prodexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ ADDOP
        // prodexp :: prodexp • MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP MULOP RPAREN RBRACKET COMMA EQ ADDOP
        new Dictionary<string,ParseAction>(){
                {"MULOP" , new ParseAction(PAction.SHIFT, 60, null, -1)},
                {"RELOP",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"$",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"BITOP",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
                {"ADDOP",new ParseAction(PAction.REDUCE, 3, "sumexp", 54)},
        },
        // DFA STATE 64
        // shiftexp :: shiftexp SHIFTOP • sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // sumexp :: • prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // prodexp :: • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ SHIFTOP
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ SHIFTOP
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ SHIFTOP
        new Dictionary<string,ParseAction>(){
                {"sumexp" , new ParseAction(PAction.SHIFT, 65, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 65
        // shiftexp :: shiftexp SHIFTOP sumexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP RPAREN RBRACKET COMMA EQ SHIFTOP
        // sumexp :: sumexp • ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP ADDOP RPAREN RBRACKET COMMA EQ SHIFTOP
        new Dictionary<string,ParseAction>(){
                {"ADDOP" , new ParseAction(PAction.SHIFT, 62, null, -1)},
                {"RELOP",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"$",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"BITOP",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
                {"SHIFTOP",new ParseAction(PAction.REDUCE, 3, "shiftexp", 52)},
        },
        // DFA STATE 66
        // relexp :: bitexp RELOP • bitexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ
        // bitexp :: • bitexp BITOP shiftexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP RPAREN RBRACKET COMMA EQ
        // bitexp :: • shiftexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP RPAREN RBRACKET COMMA EQ
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ
        // shiftexp :: • sumexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ
        // sumexp :: • sumexp ADDOP prodexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ
        // sumexp :: • prodexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ
        // prodexp :: • prodexp MULOP powexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // prodexp :: • powexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // powexp :: • unaryexp POWOP powexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // powexp :: • unaryexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • ADDOP unaryexp ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • NOTOP unaryexp ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // unaryexp :: • preincexp ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • PLUSPLUS preincexp ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // preincexp :: • postincexp ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ
        // postincexp :: • postincexp PLUSPLUS ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // postincexp :: • amfexp ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp DOT factor ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // amfexp :: • factor ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • NUM ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • LPAREN expr RPAREN ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • ID ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • FNUM ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • STRINGCONST ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        // factor :: • BOOLCONST ║ POWOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"bitexp" , new ParseAction(PAction.SHIFT, 69, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 67
        // bitexp :: bitexp BITOP • shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP RPAREN RBRACKET COMMA EQ BITOP
        // shiftexp :: • sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP RPAREN RBRACKET COMMA EQ BITOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ BITOP
        // sumexp :: • prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ BITOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // prodexp :: • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ BITOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ BITOP
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ BITOP
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ BITOP
        new Dictionary<string,ParseAction>(){
                {"shiftexp" , new ParseAction(PAction.SHIFT, 68, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 68
        // bitexp :: bitexp BITOP shiftexp • ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ BITOP
        // shiftexp :: shiftexp • SHIFTOP sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP SHIFTOP RPAREN RBRACKET COMMA EQ BITOP
        new Dictionary<string,ParseAction>(){
                {"SHIFTOP" , new ParseAction(PAction.SHIFT, 64, null, -1)},
                {"RELOP",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"$",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
                {"BITOP",new ParseAction(PAction.REDUCE, 3, "bitexp", 50)},
        },
        // DFA STATE 69
        // relexp :: bitexp RELOP bitexp • ║ SEMI FUNC CLASS VAR $ OROP ANDOP RPAREN RBRACKET COMMA EQ
        // bitexp :: bitexp • BITOP shiftexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP BITOP RPAREN RBRACKET COMMA EQ
        new Dictionary<string,ParseAction>(){
                {"BITOP" , new ParseAction(PAction.SHIFT, 67, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"$",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "relexp", 48)},
        },
        // DFA STATE 70
        // andexp :: andexp ANDOP • relexp ║ SEMI FUNC CLASS VAR $ OROP RPAREN RBRACKET COMMA EQ ANDOP
        // relexp :: • bitexp RELOP bitexp ║ SEMI FUNC CLASS VAR $ OROP RPAREN RBRACKET COMMA EQ ANDOP
        // relexp :: • bitexp ║ SEMI FUNC CLASS VAR $ OROP RPAREN RBRACKET COMMA EQ ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP RPAREN RBRACKET COMMA EQ ANDOP
        // bitexp :: • shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP RPAREN RBRACKET COMMA EQ ANDOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ ANDOP
        // shiftexp :: • sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ ANDOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ ANDOP
        // sumexp :: • prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ ANDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // prodexp :: • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ ANDOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ ANDOP
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ ANDOP
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ ANDOP
        new Dictionary<string,ParseAction>(){
                {"relexp" , new ParseAction(PAction.SHIFT, 71, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 71
        // andexp :: andexp ANDOP relexp • ║ SEMI FUNC CLASS VAR $ OROP RPAREN RBRACKET COMMA EQ ANDOP
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"$",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
                {"ANDOP",new ParseAction(PAction.REDUCE, 3, "andexp", 46)},
        },
        // DFA STATE 72
        // orexp :: orexp OROP • andexp ║ SEMI FUNC CLASS VAR $ RPAREN RBRACKET COMMA EQ OROP
        // andexp :: • andexp ANDOP relexp ║ SEMI FUNC CLASS VAR $ ANDOP RPAREN RBRACKET COMMA EQ OROP
        // andexp :: • relexp ║ SEMI FUNC CLASS VAR $ ANDOP RPAREN RBRACKET COMMA EQ OROP
        // relexp :: • bitexp RELOP bitexp ║ SEMI FUNC CLASS VAR $ ANDOP RPAREN RBRACKET COMMA EQ OROP
        // relexp :: • bitexp ║ SEMI FUNC CLASS VAR $ ANDOP RPAREN RBRACKET COMMA EQ OROP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP RPAREN RBRACKET COMMA EQ OROP
        // bitexp :: • shiftexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP RPAREN RBRACKET COMMA EQ OROP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ OROP
        // shiftexp :: • sumexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP RPAREN RBRACKET COMMA EQ OROP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ OROP
        // sumexp :: • prodexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP RPAREN RBRACKET COMMA EQ OROP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // prodexp :: • powexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP RPAREN RBRACKET COMMA EQ OROP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ OROP
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS RPAREN RBRACKET COMMA EQ OROP
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN RPAREN RBRACKET COMMA EQ OROP
        new Dictionary<string,ParseAction>(){
                {"andexp" , new ParseAction(PAction.SHIFT, 73, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 73
        // orexp :: orexp OROP andexp • ║ SEMI FUNC CLASS VAR $ RPAREN RBRACKET COMMA EQ OROP
        // andexp :: andexp • ANDOP relexp ║ SEMI FUNC CLASS VAR $ ANDOP RPAREN RBRACKET COMMA EQ OROP
        new Dictionary<string,ParseAction>(){
                {"ANDOP" , new ParseAction(PAction.SHIFT, 70, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"FUNC",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"CLASS",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"VAR",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"$",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"RBRACKET",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"EQ",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
                {"OROP",new ParseAction(PAction.REDUCE, 3, "orexp", 44)},
        },
        // DFA STATE 74
        // vardecl :: VAR ID COLON TYPE EQ • expr ║ SEMI FUNC CLASS VAR $
        // expr :: • orexp ║ SEMI FUNC CLASS VAR $
        // orexp :: • orexp OROP andexp ║ SEMI FUNC CLASS VAR $ OROP
        // orexp :: • andexp ║ SEMI FUNC CLASS VAR $ OROP
        // andexp :: • andexp ANDOP relexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // andexp :: • relexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // relexp :: • bitexp ║ SEMI FUNC CLASS VAR $ OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI FUNC CLASS VAR $ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 75, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 75
        // vardecl :: VAR ID COLON TYPE EQ expr • ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 6, "vardecl", 40)},
                {"FUNC",new ParseAction(PAction.REDUCE, 6, "vardecl", 40)},
                {"CLASS",new ParseAction(PAction.REDUCE, 6, "vardecl", 40)},
                {"VAR",new ParseAction(PAction.REDUCE, 6, "vardecl", 40)},
                {"$",new ParseAction(PAction.REDUCE, 6, "vardecl", 40)},
        },
        // DFA STATE 76
        // classdecl :: CLASS ID • LBRACE memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"LBRACE" , new ParseAction(PAction.SHIFT, 77, null, -1)},
        },
        // DFA STATE 77
        // classdecl :: CLASS ID LBRACE • memberdecls RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        // memberdecls :: • ║ RBRACE
        // memberdecls :: • SEMI memberdecls ║ RBRACE
        // memberdecls :: • membervardecl memberdecls ║ RBRACE
        // memberdecls :: • memberfuncdecl memberdecls ║ RBRACE
        // membervardecl :: • VAR ID COLON TYPE SEMI ║ SEMI VAR FUNC RBRACE
        // memberfuncdecl :: • funcdecl ║ SEMI VAR FUNC RBRACE
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"memberdecls" , new ParseAction(PAction.SHIFT, 78, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 79, null, -1)},
                {"membervardecl" , new ParseAction(PAction.SHIFT, 80, null, -1)},
                {"memberfuncdecl" , new ParseAction(PAction.SHIFT, 81, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 82, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 83, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 0, "memberdecls", 18)},
        },
        // DFA STATE 78
        // classdecl :: CLASS ID LBRACE memberdecls • RBRACE SEMI ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"RBRACE" , new ParseAction(PAction.SHIFT, 91, null, -1)},
        },
        // DFA STATE 79
        // memberdecls :: SEMI • memberdecls ║ RBRACE
        // memberdecls :: • ║ RBRACE
        // memberdecls :: • SEMI memberdecls ║ RBRACE
        // memberdecls :: • membervardecl memberdecls ║ RBRACE
        // memberdecls :: • memberfuncdecl memberdecls ║ RBRACE
        // membervardecl :: • VAR ID COLON TYPE SEMI ║ SEMI VAR FUNC RBRACE
        // memberfuncdecl :: • funcdecl ║ SEMI VAR FUNC RBRACE
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"memberdecls" , new ParseAction(PAction.SHIFT, 90, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 79, null, -1)},
                {"membervardecl" , new ParseAction(PAction.SHIFT, 80, null, -1)},
                {"memberfuncdecl" , new ParseAction(PAction.SHIFT, 81, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 82, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 83, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 0, "memberdecls", 18)},
        },
        // DFA STATE 80
        // memberdecls :: membervardecl • memberdecls ║ RBRACE
        // memberdecls :: • ║ RBRACE
        // memberdecls :: • SEMI memberdecls ║ RBRACE
        // memberdecls :: • membervardecl memberdecls ║ RBRACE
        // memberdecls :: • memberfuncdecl memberdecls ║ RBRACE
        // membervardecl :: • VAR ID COLON TYPE SEMI ║ SEMI VAR FUNC RBRACE
        // memberfuncdecl :: • funcdecl ║ SEMI VAR FUNC RBRACE
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"memberdecls" , new ParseAction(PAction.SHIFT, 89, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 79, null, -1)},
                {"membervardecl" , new ParseAction(PAction.SHIFT, 80, null, -1)},
                {"memberfuncdecl" , new ParseAction(PAction.SHIFT, 81, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 82, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 83, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 0, "memberdecls", 18)},
        },
        // DFA STATE 81
        // memberdecls :: memberfuncdecl • memberdecls ║ RBRACE
        // memberdecls :: • ║ RBRACE
        // memberdecls :: • SEMI memberdecls ║ RBRACE
        // memberdecls :: • membervardecl memberdecls ║ RBRACE
        // memberdecls :: • memberfuncdecl memberdecls ║ RBRACE
        // membervardecl :: • VAR ID COLON TYPE SEMI ║ SEMI VAR FUNC RBRACE
        // memberfuncdecl :: • funcdecl ║ SEMI VAR FUNC RBRACE
        // funcdecl :: • FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"memberdecls" , new ParseAction(PAction.SHIFT, 88, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 79, null, -1)},
                {"membervardecl" , new ParseAction(PAction.SHIFT, 80, null, -1)},
                {"memberfuncdecl" , new ParseAction(PAction.SHIFT, 81, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 82, null, -1)},
                {"funcdecl" , new ParseAction(PAction.SHIFT, 83, null, -1)},
                {"FUNC" , new ParseAction(PAction.SHIFT, 7, null, -1)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 0, "memberdecls", 18)},
        },
        // DFA STATE 82
        // membervardecl :: VAR • ID COLON TYPE SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"ID" , new ParseAction(PAction.SHIFT, 84, null, -1)},
        },
        // DFA STATE 83
        // memberfuncdecl :: funcdecl • ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "memberfuncdecl", 23)},
                {"VAR",new ParseAction(PAction.REDUCE, 1, "memberfuncdecl", 23)},
                {"FUNC",new ParseAction(PAction.REDUCE, 1, "memberfuncdecl", 23)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 1, "memberfuncdecl", 23)},
        },
        // DFA STATE 84
        // membervardecl :: VAR ID • COLON TYPE SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"COLON" , new ParseAction(PAction.SHIFT, 85, null, -1)},
        },
        // DFA STATE 85
        // membervardecl :: VAR ID COLON • TYPE SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"TYPE" , new ParseAction(PAction.SHIFT, 86, null, -1)},
        },
        // DFA STATE 86
        // membervardecl :: VAR ID COLON TYPE • SEMI ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 87, null, -1)},
        },
        // DFA STATE 87
        // membervardecl :: VAR ID COLON TYPE SEMI • ║ SEMI VAR FUNC RBRACE
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 5, "membervardecl", 22)},
                {"VAR",new ParseAction(PAction.REDUCE, 5, "membervardecl", 22)},
                {"FUNC",new ParseAction(PAction.REDUCE, 5, "membervardecl", 22)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 5, "membervardecl", 22)},
        },
        // DFA STATE 88
        // memberdecls :: memberfuncdecl memberdecls • ║ RBRACE
        new Dictionary<string,ParseAction>(){
                {"RBRACE",new ParseAction(PAction.REDUCE, 2, "memberdecls", 21)},
        },
        // DFA STATE 89
        // memberdecls :: membervardecl memberdecls • ║ RBRACE
        new Dictionary<string,ParseAction>(){
                {"RBRACE",new ParseAction(PAction.REDUCE, 2, "memberdecls", 20)},
        },
        // DFA STATE 90
        // memberdecls :: SEMI memberdecls • ║ RBRACE
        new Dictionary<string,ParseAction>(){
                {"RBRACE",new ParseAction(PAction.REDUCE, 2, "memberdecls", 19)},
        },
        // DFA STATE 91
        // classdecl :: CLASS ID LBRACE memberdecls RBRACE • SEMI ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 92, null, -1)},
        },
        // DFA STATE 92
        // classdecl :: CLASS ID LBRACE memberdecls RBRACE SEMI • ║ SEMI FUNC CLASS VAR $
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 6, "classdecl", 17)},
                {"FUNC",new ParseAction(PAction.REDUCE, 6, "classdecl", 17)},
                {"CLASS",new ParseAction(PAction.REDUCE, 6, "classdecl", 17)},
                {"VAR",new ParseAction(PAction.REDUCE, 6, "classdecl", 17)},
                {"$",new ParseAction(PAction.REDUCE, 6, "classdecl", 17)},
        },
        // DFA STATE 93
        // funcdecl :: FUNC ID • LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        new Dictionary<string,ParseAction>(){
                {"LPAREN" , new ParseAction(PAction.SHIFT, 94, null, -1)},
        },
        // DFA STATE 94
        // funcdecl :: FUNC ID LPAREN • optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        // optionalPdecls :: • ║ RPAREN
        // optionalPdecls :: • pdecls ║ RPAREN
        // pdecls :: • pdecl ║ RPAREN
        // pdecls :: • pdecl COMMA pdecls ║ RPAREN
        // pdecl :: • ID COLON TYPE ║ RPAREN COMMA
        new Dictionary<string,ParseAction>(){
                {"optionalPdecls" , new ParseAction(PAction.SHIFT, 95, null, -1)},
                {"pdecls" , new ParseAction(PAction.SHIFT, 96, null, -1)},
                {"pdecl" , new ParseAction(PAction.SHIFT, 97, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 98, null, -1)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 0, "optionalPdecls", 12)},
        },
        // DFA STATE 95
        // funcdecl :: FUNC ID LPAREN optionalPdecls • RPAREN optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 103, null, -1)},
        },
        // DFA STATE 96
        // optionalPdecls :: pdecls • ║ RPAREN
        new Dictionary<string,ParseAction>(){
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "optionalPdecls", 13)},
        },
        // DFA STATE 97
        // pdecls :: pdecl • ║ RPAREN
        // pdecls :: pdecl • COMMA pdecls ║ RPAREN
        new Dictionary<string,ParseAction>(){
                {"COMMA" , new ParseAction(PAction.SHIFT, 101, null, -1)},
                {"RPAREN",new ParseAction(PAction.REDUCE, 1, "pdecls", 14)},
        },
        // DFA STATE 98
        // pdecl :: ID • COLON TYPE ║ RPAREN COMMA
        new Dictionary<string,ParseAction>(){
                {"COLON" , new ParseAction(PAction.SHIFT, 99, null, -1)},
        },
        // DFA STATE 99
        // pdecl :: ID COLON • TYPE ║ RPAREN COMMA
        new Dictionary<string,ParseAction>(){
                {"TYPE" , new ParseAction(PAction.SHIFT, 100, null, -1)},
        },
        // DFA STATE 100
        // pdecl :: ID COLON TYPE • ║ RPAREN COMMA
        new Dictionary<string,ParseAction>(){
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "pdecl", 16)},
                {"COMMA",new ParseAction(PAction.REDUCE, 3, "pdecl", 16)},
        },
        // DFA STATE 101
        // pdecls :: pdecl COMMA • pdecls ║ RPAREN
        // pdecls :: • pdecl ║ RPAREN
        // pdecls :: • pdecl COMMA pdecls ║ RPAREN
        // pdecl :: • ID COLON TYPE ║ RPAREN COMMA
        new Dictionary<string,ParseAction>(){
                {"pdecls" , new ParseAction(PAction.SHIFT, 102, null, -1)},
                {"pdecl" , new ParseAction(PAction.SHIFT, 97, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 98, null, -1)},
        },
        // DFA STATE 102
        // pdecls :: pdecl COMMA pdecls • ║ RPAREN
        new Dictionary<string,ParseAction>(){
                {"RPAREN",new ParseAction(PAction.REDUCE, 3, "pdecls", 15)},
        },
        // DFA STATE 103
        // funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN • optionalReturn LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        // optionalReturn :: • ║ LBRACE
        // optionalReturn :: • COLON TYPE ║ LBRACE
        new Dictionary<string,ParseAction>(){
                {"optionalReturn" , new ParseAction(PAction.SHIFT, 104, null, -1)},
                {"COLON" , new ParseAction(PAction.SHIFT, 105, null, -1)},
                {"LBRACE",new ParseAction(PAction.REDUCE, 0, "optionalReturn", 8)},
        },
        // DFA STATE 104
        // funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn • LBRACE stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        new Dictionary<string,ParseAction>(){
                {"LBRACE" , new ParseAction(PAction.SHIFT, 107, null, -1)},
        },
        // DFA STATE 105
        // optionalReturn :: COLON • TYPE ║ LBRACE
        new Dictionary<string,ParseAction>(){
                {"TYPE" , new ParseAction(PAction.SHIFT, 106, null, -1)},
        },
        // DFA STATE 106
        // optionalReturn :: COLON TYPE • ║ LBRACE
        new Dictionary<string,ParseAction>(){
                {"LBRACE",new ParseAction(PAction.REDUCE, 2, "optionalReturn", 9)},
        },
        // DFA STATE 107
        // funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE • stmts RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        // stmts :: • stmt SEMI stmts ║ RBRACE
        // stmts :: • SEMI ║ RBRACE
        // stmts :: • ║ RBRACE
        // stmt :: • assign ║ SEMI
        // stmt :: • cond ║ SEMI
        // stmt :: • loop ║ SEMI
        // stmt :: • vardecl ║ SEMI
        // stmt :: • return ║ SEMI
        // assign :: • expr EQ expr ║ SEMI
        // cond :: • IF LPAREN expr RPAREN braceblock ║ SEMI
        // cond :: • IF LPAREN expr RPAREN braceblock ELSE braceblock ║ SEMI
        // loop :: • WHILE LPAREN expr RPAREN braceblock ║ SEMI
        // loop :: • REPEAT braceblock UNTIL LPAREN expr RPAREN ║ SEMI
        // vardecl :: • VAR ID COLON TYPE ║ SEMI
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI
        // vardecl :: • VAR ID COLON ID ║ SEMI
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI
        // return :: • RETURN expr ║ SEMI
        // return :: • RETURN ║ SEMI
        // expr :: • orexp ║ EQ
        // orexp :: • orexp OROP andexp ║ EQ OROP
        // orexp :: • andexp ║ EQ OROP
        // andexp :: • andexp ANDOP relexp ║ EQ OROP ANDOP
        // andexp :: • relexp ║ EQ OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ EQ OROP ANDOP
        // relexp :: • bitexp ║ EQ OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP EQ OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP EQ OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"stmts" , new ParseAction(PAction.SHIFT, 108, null, -1)},
                {"stmt" , new ParseAction(PAction.SHIFT, 109, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 110, null, -1)},
                {"assign" , new ParseAction(PAction.SHIFT, 111, null, -1)},
                {"cond" , new ParseAction(PAction.SHIFT, 112, null, -1)},
                {"loop" , new ParseAction(PAction.SHIFT, 113, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 114, null, -1)},
                {"return" , new ParseAction(PAction.SHIFT, 115, null, -1)},
                {"expr" , new ParseAction(PAction.SHIFT, 116, null, -1)},
                {"IF" , new ParseAction(PAction.SHIFT, 117, null, -1)},
                {"WHILE" , new ParseAction(PAction.SHIFT, 118, null, -1)},
                {"REPEAT" , new ParseAction(PAction.SHIFT, 119, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"RETURN" , new ParseAction(PAction.SHIFT, 120, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 0, "stmts", 26)},
        },
        // DFA STATE 108
        // funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts • RBRACE SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        new Dictionary<string,ParseAction>(){
                {"RBRACE" , new ParseAction(PAction.SHIFT, 144, null, -1)},
        },
        // DFA STATE 109
        // stmts :: stmt • SEMI stmts ║ RBRACE
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 142, null, -1)},
        },
        // DFA STATE 110
        // stmts :: SEMI • ║ RBRACE
        new Dictionary<string,ParseAction>(){
                {"RBRACE",new ParseAction(PAction.REDUCE, 1, "stmts", 25)},
        },
        // DFA STATE 111
        // stmt :: assign • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "stmt", 27)},
        },
        // DFA STATE 112
        // stmt :: cond • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "stmt", 28)},
        },
        // DFA STATE 113
        // stmt :: loop • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "stmt", 29)},
        },
        // DFA STATE 114
        // stmt :: vardecl • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "stmt", 30)},
        },
        // DFA STATE 115
        // stmt :: return • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "stmt", 31)},
        },
        // DFA STATE 116
        // assign :: expr • EQ expr ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"EQ" , new ParseAction(PAction.SHIFT, 140, null, -1)},
        },
        // DFA STATE 117
        // cond :: IF • LPAREN expr RPAREN braceblock ║ SEMI
        // cond :: IF • LPAREN expr RPAREN braceblock ELSE braceblock ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"LPAREN" , new ParseAction(PAction.SHIFT, 134, null, -1)},
        },
        // DFA STATE 118
        // loop :: WHILE • LPAREN expr RPAREN braceblock ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"LPAREN" , new ParseAction(PAction.SHIFT, 130, null, -1)},
        },
        // DFA STATE 119
        // loop :: REPEAT • braceblock UNTIL LPAREN expr RPAREN ║ SEMI
        // braceblock :: • LBRACE stmts RBRACE ║ UNTIL
        new Dictionary<string,ParseAction>(){
                {"braceblock" , new ParseAction(PAction.SHIFT, 122, null, -1)},
                {"LBRACE" , new ParseAction(PAction.SHIFT, 123, null, -1)},
        },
        // DFA STATE 120
        // return :: RETURN • expr ║ SEMI
        // return :: RETURN • ║ SEMI
        // expr :: • orexp ║ SEMI
        // orexp :: • orexp OROP andexp ║ SEMI OROP
        // orexp :: • andexp ║ SEMI OROP
        // andexp :: • andexp ANDOP relexp ║ SEMI OROP ANDOP
        // andexp :: • relexp ║ SEMI OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ SEMI OROP ANDOP
        // relexp :: • bitexp ║ SEMI OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP SEMI OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP SEMI OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 121, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 1, "return", 38)},
        },
        // DFA STATE 121
        // return :: RETURN expr • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 2, "return", 37)},
        },
        // DFA STATE 122
        // loop :: REPEAT braceblock • UNTIL LPAREN expr RPAREN ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"UNTIL" , new ParseAction(PAction.SHIFT, 126, null, -1)},
        },
        // DFA STATE 123
        // braceblock :: LBRACE • stmts RBRACE ║ UNTIL SEMI ELSE
        // stmts :: • stmt SEMI stmts ║ RBRACE
        // stmts :: • SEMI ║ RBRACE
        // stmts :: • ║ RBRACE
        // stmt :: • assign ║ SEMI
        // stmt :: • cond ║ SEMI
        // stmt :: • loop ║ SEMI
        // stmt :: • vardecl ║ SEMI
        // stmt :: • return ║ SEMI
        // assign :: • expr EQ expr ║ SEMI
        // cond :: • IF LPAREN expr RPAREN braceblock ║ SEMI
        // cond :: • IF LPAREN expr RPAREN braceblock ELSE braceblock ║ SEMI
        // loop :: • WHILE LPAREN expr RPAREN braceblock ║ SEMI
        // loop :: • REPEAT braceblock UNTIL LPAREN expr RPAREN ║ SEMI
        // vardecl :: • VAR ID COLON TYPE ║ SEMI
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI
        // vardecl :: • VAR ID COLON ID ║ SEMI
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI
        // return :: • RETURN expr ║ SEMI
        // return :: • RETURN ║ SEMI
        // expr :: • orexp ║ EQ
        // orexp :: • orexp OROP andexp ║ EQ OROP
        // orexp :: • andexp ║ EQ OROP
        // andexp :: • andexp ANDOP relexp ║ EQ OROP ANDOP
        // andexp :: • relexp ║ EQ OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ EQ OROP ANDOP
        // relexp :: • bitexp ║ EQ OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP EQ OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP EQ OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"stmts" , new ParseAction(PAction.SHIFT, 124, null, -1)},
                {"stmt" , new ParseAction(PAction.SHIFT, 109, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 110, null, -1)},
                {"assign" , new ParseAction(PAction.SHIFT, 111, null, -1)},
                {"cond" , new ParseAction(PAction.SHIFT, 112, null, -1)},
                {"loop" , new ParseAction(PAction.SHIFT, 113, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 114, null, -1)},
                {"return" , new ParseAction(PAction.SHIFT, 115, null, -1)},
                {"expr" , new ParseAction(PAction.SHIFT, 116, null, -1)},
                {"IF" , new ParseAction(PAction.SHIFT, 117, null, -1)},
                {"WHILE" , new ParseAction(PAction.SHIFT, 118, null, -1)},
                {"REPEAT" , new ParseAction(PAction.SHIFT, 119, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"RETURN" , new ParseAction(PAction.SHIFT, 120, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 0, "stmts", 26)},
        },
        // DFA STATE 124
        // braceblock :: LBRACE stmts • RBRACE ║ UNTIL SEMI ELSE
        new Dictionary<string,ParseAction>(){
                {"RBRACE" , new ParseAction(PAction.SHIFT, 125, null, -1)},
        },
        // DFA STATE 125
        // braceblock :: LBRACE stmts RBRACE • ║ UNTIL SEMI ELSE
        new Dictionary<string,ParseAction>(){
                {"UNTIL",new ParseAction(PAction.REDUCE, 3, "braceblock", 7)},
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "braceblock", 7)},
                {"ELSE",new ParseAction(PAction.REDUCE, 3, "braceblock", 7)},
        },
        // DFA STATE 126
        // loop :: REPEAT braceblock UNTIL • LPAREN expr RPAREN ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"LPAREN" , new ParseAction(PAction.SHIFT, 127, null, -1)},
        },
        // DFA STATE 127
        // loop :: REPEAT braceblock UNTIL LPAREN • expr RPAREN ║ SEMI
        // expr :: • orexp ║ RPAREN
        // orexp :: • orexp OROP andexp ║ RPAREN OROP
        // orexp :: • andexp ║ RPAREN OROP
        // andexp :: • andexp ANDOP relexp ║ RPAREN OROP ANDOP
        // andexp :: • relexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp ║ RPAREN OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 128, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 128
        // loop :: REPEAT braceblock UNTIL LPAREN expr • RPAREN ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 129, null, -1)},
        },
        // DFA STATE 129
        // loop :: REPEAT braceblock UNTIL LPAREN expr RPAREN • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 6, "loop", 36)},
        },
        // DFA STATE 130
        // loop :: WHILE LPAREN • expr RPAREN braceblock ║ SEMI
        // expr :: • orexp ║ RPAREN
        // orexp :: • orexp OROP andexp ║ RPAREN OROP
        // orexp :: • andexp ║ RPAREN OROP
        // andexp :: • andexp ANDOP relexp ║ RPAREN OROP ANDOP
        // andexp :: • relexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp ║ RPAREN OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 131, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 131
        // loop :: WHILE LPAREN expr • RPAREN braceblock ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 132, null, -1)},
        },
        // DFA STATE 132
        // loop :: WHILE LPAREN expr RPAREN • braceblock ║ SEMI
        // braceblock :: • LBRACE stmts RBRACE ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"braceblock" , new ParseAction(PAction.SHIFT, 133, null, -1)},
                {"LBRACE" , new ParseAction(PAction.SHIFT, 123, null, -1)},
        },
        // DFA STATE 133
        // loop :: WHILE LPAREN expr RPAREN braceblock • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 5, "loop", 35)},
        },
        // DFA STATE 134
        // cond :: IF LPAREN • expr RPAREN braceblock ║ SEMI
        // cond :: IF LPAREN • expr RPAREN braceblock ELSE braceblock ║ SEMI
        // expr :: • orexp ║ RPAREN
        // orexp :: • orexp OROP andexp ║ RPAREN OROP
        // orexp :: • andexp ║ RPAREN OROP
        // andexp :: • andexp ANDOP relexp ║ RPAREN OROP ANDOP
        // andexp :: • relexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ RPAREN OROP ANDOP
        // relexp :: • bitexp ║ RPAREN OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP RPAREN OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP RPAREN OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 135, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 135
        // cond :: IF LPAREN expr • RPAREN braceblock ║ SEMI
        // cond :: IF LPAREN expr • RPAREN braceblock ELSE braceblock ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"RPAREN" , new ParseAction(PAction.SHIFT, 136, null, -1)},
        },
        // DFA STATE 136
        // cond :: IF LPAREN expr RPAREN • braceblock ║ SEMI
        // cond :: IF LPAREN expr RPAREN • braceblock ELSE braceblock ║ SEMI
        // braceblock :: • LBRACE stmts RBRACE ║ SEMI ELSE
        new Dictionary<string,ParseAction>(){
                {"braceblock" , new ParseAction(PAction.SHIFT, 137, null, -1)},
                {"LBRACE" , new ParseAction(PAction.SHIFT, 123, null, -1)},
        },
        // DFA STATE 137
        // cond :: IF LPAREN expr RPAREN braceblock • ║ SEMI
        // cond :: IF LPAREN expr RPAREN braceblock • ELSE braceblock ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"ELSE" , new ParseAction(PAction.SHIFT, 138, null, -1)},
                {"SEMI",new ParseAction(PAction.REDUCE, 5, "cond", 33)},
        },
        // DFA STATE 138
        // cond :: IF LPAREN expr RPAREN braceblock ELSE • braceblock ║ SEMI
        // braceblock :: • LBRACE stmts RBRACE ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"braceblock" , new ParseAction(PAction.SHIFT, 139, null, -1)},
                {"LBRACE" , new ParseAction(PAction.SHIFT, 123, null, -1)},
        },
        // DFA STATE 139
        // cond :: IF LPAREN expr RPAREN braceblock ELSE braceblock • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 7, "cond", 34)},
        },
        // DFA STATE 140
        // assign :: expr EQ • expr ║ SEMI
        // expr :: • orexp ║ SEMI
        // orexp :: • orexp OROP andexp ║ SEMI OROP
        // orexp :: • andexp ║ SEMI OROP
        // andexp :: • andexp ANDOP relexp ║ SEMI OROP ANDOP
        // andexp :: • relexp ║ SEMI OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ SEMI OROP ANDOP
        // relexp :: • bitexp ║ SEMI OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP SEMI OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP SEMI OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP SEMI OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"expr" , new ParseAction(PAction.SHIFT, 141, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
        },
        // DFA STATE 141
        // assign :: expr EQ expr • ║ SEMI
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 3, "assign", 32)},
        },
        // DFA STATE 142
        // stmts :: stmt SEMI • stmts ║ RBRACE
        // stmts :: • stmt SEMI stmts ║ RBRACE
        // stmts :: • SEMI ║ RBRACE
        // stmts :: • ║ RBRACE
        // stmt :: • assign ║ SEMI
        // stmt :: • cond ║ SEMI
        // stmt :: • loop ║ SEMI
        // stmt :: • vardecl ║ SEMI
        // stmt :: • return ║ SEMI
        // assign :: • expr EQ expr ║ SEMI
        // cond :: • IF LPAREN expr RPAREN braceblock ║ SEMI
        // cond :: • IF LPAREN expr RPAREN braceblock ELSE braceblock ║ SEMI
        // loop :: • WHILE LPAREN expr RPAREN braceblock ║ SEMI
        // loop :: • REPEAT braceblock UNTIL LPAREN expr RPAREN ║ SEMI
        // vardecl :: • VAR ID COLON TYPE ║ SEMI
        // vardecl :: • VAR ID COLON TYPE EQ expr ║ SEMI
        // vardecl :: • VAR ID COLON ID ║ SEMI
        // vardecl :: • VAR ID COLON ID EQ expr ║ SEMI
        // return :: • RETURN expr ║ SEMI
        // return :: • RETURN ║ SEMI
        // expr :: • orexp ║ EQ
        // orexp :: • orexp OROP andexp ║ EQ OROP
        // orexp :: • andexp ║ EQ OROP
        // andexp :: • andexp ANDOP relexp ║ EQ OROP ANDOP
        // andexp :: • relexp ║ EQ OROP ANDOP
        // relexp :: • bitexp RELOP bitexp ║ EQ OROP ANDOP
        // relexp :: • bitexp ║ EQ OROP ANDOP
        // bitexp :: • bitexp BITOP shiftexp ║ RELOP EQ OROP ANDOP BITOP
        // bitexp :: • shiftexp ║ RELOP EQ OROP ANDOP BITOP
        // shiftexp :: • shiftexp SHIFTOP sumexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP
        // shiftexp :: • sumexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP
        // sumexp :: • sumexp ADDOP prodexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP
        // sumexp :: • prodexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP
        // prodexp :: • prodexp MULOP powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // prodexp :: • powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp POWOP powexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // powexp :: • unaryexp ║ RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • BITNOTOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • ADDOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • NOTOP unaryexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // unaryexp :: • preincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • PLUSPLUS preincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // preincexp :: • postincexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP
        // postincexp :: • postincexp PLUSPLUS ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // postincexp :: • amfexp ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS
        // amfexp :: • amfexp DOT factor ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LBRACKET expr RBRACKET ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • amfexp LPAREN calllist RPAREN ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // amfexp :: • factor ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • NUM ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • LPAREN expr RPAREN ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • ID ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • FNUM ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • STRINGCONST ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        // factor :: • BOOLCONST ║ POWOP RELOP EQ OROP ANDOP BITOP SHIFTOP ADDOP MULOP PLUSPLUS DOT LBRACKET LPAREN
        new Dictionary<string,ParseAction>(){
                {"stmts" , new ParseAction(PAction.SHIFT, 143, null, -1)},
                {"stmt" , new ParseAction(PAction.SHIFT, 109, null, -1)},
                {"SEMI" , new ParseAction(PAction.SHIFT, 110, null, -1)},
                {"assign" , new ParseAction(PAction.SHIFT, 111, null, -1)},
                {"cond" , new ParseAction(PAction.SHIFT, 112, null, -1)},
                {"loop" , new ParseAction(PAction.SHIFT, 113, null, -1)},
                {"vardecl" , new ParseAction(PAction.SHIFT, 114, null, -1)},
                {"return" , new ParseAction(PAction.SHIFT, 115, null, -1)},
                {"expr" , new ParseAction(PAction.SHIFT, 116, null, -1)},
                {"IF" , new ParseAction(PAction.SHIFT, 117, null, -1)},
                {"WHILE" , new ParseAction(PAction.SHIFT, 118, null, -1)},
                {"REPEAT" , new ParseAction(PAction.SHIFT, 119, null, -1)},
                {"VAR" , new ParseAction(PAction.SHIFT, 9, null, -1)},
                {"RETURN" , new ParseAction(PAction.SHIFT, 120, null, -1)},
                {"orexp" , new ParseAction(PAction.SHIFT, 16, null, -1)},
                {"andexp" , new ParseAction(PAction.SHIFT, 17, null, -1)},
                {"relexp" , new ParseAction(PAction.SHIFT, 18, null, -1)},
                {"bitexp" , new ParseAction(PAction.SHIFT, 19, null, -1)},
                {"shiftexp" , new ParseAction(PAction.SHIFT, 20, null, -1)},
                {"sumexp" , new ParseAction(PAction.SHIFT, 21, null, -1)},
                {"prodexp" , new ParseAction(PAction.SHIFT, 22, null, -1)},
                {"powexp" , new ParseAction(PAction.SHIFT, 23, null, -1)},
                {"unaryexp" , new ParseAction(PAction.SHIFT, 24, null, -1)},
                {"BITNOTOP" , new ParseAction(PAction.SHIFT, 25, null, -1)},
                {"ADDOP" , new ParseAction(PAction.SHIFT, 26, null, -1)},
                {"NOTOP" , new ParseAction(PAction.SHIFT, 27, null, -1)},
                {"preincexp" , new ParseAction(PAction.SHIFT, 28, null, -1)},
                {"PLUSPLUS" , new ParseAction(PAction.SHIFT, 29, null, -1)},
                {"postincexp" , new ParseAction(PAction.SHIFT, 30, null, -1)},
                {"amfexp" , new ParseAction(PAction.SHIFT, 31, null, -1)},
                {"factor" , new ParseAction(PAction.SHIFT, 32, null, -1)},
                {"NUM" , new ParseAction(PAction.SHIFT, 33, null, -1)},
                {"LPAREN" , new ParseAction(PAction.SHIFT, 34, null, -1)},
                {"ID" , new ParseAction(PAction.SHIFT, 35, null, -1)},
                {"FNUM" , new ParseAction(PAction.SHIFT, 36, null, -1)},
                {"STRINGCONST" , new ParseAction(PAction.SHIFT, 37, null, -1)},
                {"BOOLCONST" , new ParseAction(PAction.SHIFT, 38, null, -1)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 0, "stmts", 26)},
        },
        // DFA STATE 143
        // stmts :: stmt SEMI stmts • ║ RBRACE
        new Dictionary<string,ParseAction>(){
                {"RBRACE",new ParseAction(PAction.REDUCE, 3, "stmts", 24)},
        },
        // DFA STATE 144
        // funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE • SEMI ║ SEMI FUNC CLASS VAR $ RBRACE
        new Dictionary<string,ParseAction>(){
                {"SEMI" , new ParseAction(PAction.SHIFT, 145, null, -1)},
        },
        // DFA STATE 145
        // funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI • ║ SEMI FUNC CLASS VAR $ RBRACE
        new Dictionary<string,ParseAction>(){
                {"SEMI",new ParseAction(PAction.REDUCE, 10, "funcdecl", 6)},
                {"FUNC",new ParseAction(PAction.REDUCE, 10, "funcdecl", 6)},
                {"CLASS",new ParseAction(PAction.REDUCE, 10, "funcdecl", 6)},
                {"VAR",new ParseAction(PAction.REDUCE, 10, "funcdecl", 6)},
                {"$",new ParseAction(PAction.REDUCE, 10, "funcdecl", 6)},
                {"RBRACE",new ParseAction(PAction.REDUCE, 10, "funcdecl", 6)},
        },
        // DFA STATE 146
        // decls :: SEMI decls • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 2, "decls", 4)},
        },
        // DFA STATE 147
        // decls :: vardecl decls • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 2, "decls", 3)},
        },
        // DFA STATE 148
        // decls :: classdecl decls • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 2, "decls", 2)},
        },
        // DFA STATE 149
        // decls :: funcdecl decls • ║ $
        new Dictionary<string,ParseAction>(){
                {"$",new ParseAction(PAction.REDUCE, 2, "decls", 1)},
        },
    }; //close the table initializer
} //close the ParseTable class
} //close the namespace lab thing
