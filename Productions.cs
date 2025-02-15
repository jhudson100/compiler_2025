
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            new(@"S :: decls"),
            new(@"decls :: funcdecl decls | classdecl decls | vardecl decls | SEMI decls | lambda"),
            new(@"funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI"),
            new(@"braceblock :: LBRACE stmts RBRACE"),
            new(@"optionalReturn :: lambda | COLON TYPE"),
            new(@"optionalSemi :: lambda | SEMI"),
            new(@"optionalPdecls :: lambda | pdecls"),
            new(@"pdecls :: pdecl | pdecl COMMA pdecls"),
            new(@"pdecl :: ID COLON TYPE"),
            new(@"classdecl :: CLASS ID LBRACE memberdecls RBRACE SEMI"),
            new(@"memberdecls :: lambda | SEMI memberdecls | membervardecl memberdecls | memberfuncdecl memberdecls"),
            new(@"membervardecl :: VAR ID COLON TYPE SEMI"),
            new(@"memberfuncdecl :: funcdecl"),
            new(@"stmts :: stmt SEMI stmts 
                         | SEMI
                         | lambda"),
            new(@"stmt :: assign | cond | loop | vardecl | return"),
            new(@"assign :: expr EQ expr"),
            new(@"cond :: IF LPAREN expr RPAREN braceblock
                        | IF LPAREN expr RPAREN braceblock ELSE braceblock"),
            new(@"loop :: WHILE LPAREN expr RPAREN braceblock
                        | REPEAT braceblock UNTIL LPAREN expr RPAREN"),
            new(@"return :: RETURN expr
                          | RETURN"),
            new(@"vardecl :: VAR ID COLON TYPE
						   | VAR ID COLON ID"),//for user-defined types
            new(@"expr :: orexp"),
            new(@"orexp :: orexp OROP andexp
                         | andexp"),
            new(@"andexp :: andexp ANDOP relexp
                          |  relexp"),
            new(@"relexp :: bitexp RELOP bitexp
                          | bitexp"),
            new(@"bitexp :: bitexp BITOP shiftexp
                          | shiftexp"),
            new(@"shiftexp :: shiftexp SHIFTOP sumexp
                            | sumexp"),
            new(@"sumexp :: sumexp ADDOP prodexp
                          | prodexp"),
            new(@"prodexp :: prodexp MULOP powexp
                           | powexp"),
            new(@"powexp :: unaryexp POWOP powexp
                          | unaryexp"),
            new(@"unaryexp :: BITNOTOP unaryexp
                            | NOTOP unaryexp
                            | ADDOP unaryexp
                            | preincexp"),
            new(@"preincexp :: PLUSPLUS preincexp
                             | postincexp"),
            new(@"postincexp :: postincexp PLUSPLUS
                              | amfexp"),
            new(@"amfexp :: amfexp DOT factor
                          | amfexp LBRACKET expr RBRACKET
                          | amfexp LPAREN calllist RPAREN
                          | factor"),
            new(@"factor :: NUM
                          | LPAREN expr RPAREN
                          | ID
                          | FNUM
                          | STRINGCONST
                          | BOOLCONST"),
            new(@"calllist :: lambda
                            | calllist2 COMMA expr"),
            new(@"calllist2 :: expr
                             | calllist2 COMMA expr")
        } //end new PSpec
        );//end Grammar.defineProductions()
    }//end makeThem()
} //end class Productions

} //namespace
