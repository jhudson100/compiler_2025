
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            new("S :: decls"),
            new("decls :: funcdecl decls | classdecl decls | vardecl decls | SEMI decls | lambda"),
            new("funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI",
                collectFunctionNames: (n) => {
                    string funcName = n.children[1].token.lexeme;
                    Console.WriteLine($"FUNC: {funcName}");
            }),
            new("braceblock :: LBRACE stmts RBRACE"),
            new("optionalReturn :: lambda | COLON TYPE"),
            new("optionalSemi :: lambda | SEMI"),
            new("optionalPdecls :: lambda | pdecls"),
            new("pdecls :: pdecl | pdecl COMMA pdecls"),
            new("pdecl :: ID COLON TYPE"),
            new("classdecl :: CLASS ID LBRACE memberdecls RBRACE SEMI",
                collectClassNames: (TreeNode n) => {
                    string className = n.children[1].token.lexeme;
                    Console.WriteLine($"CLASS: {className}");
                    //assuming no nested classes; no need to walk
                    //children of n
                    //This also means we won't pick up member
                    //functions of the class.
                }
            ),
            new("memberdecls :: lambda | SEMI memberdecls | membervardecl memberdecls | memberfuncdecl memberdecls"),
            new("membervardecl :: VAR ID COLON TYPE SEMI"),
            new("memberfuncdecl :: funcdecl"),

            new("stmts :: stmt SEMI stmts"),
            new("stmts :: SEMI"),
            new("stmts :: lambda"),
            new("stmt :: assign | cond | loop | vardecl | return"),
            new("assign :: expr EQ expr"),
            new("cond :: IF LPAREN expr RPAREN braceblock"),
            new("cond :: IF LPAREN expr RPAREN braceblock ELSE braceblock"),
            new("loop :: WHILE LPAREN expr RPAREN braceblock"),
            new("loop :: REPEAT braceblock UNTIL LPAREN expr RPAREN"),
            new("return :: RETURN expr"),
            new("return :: RETURN"),
            new("vardecl :: VAR ID COLON TYPE"),
            new("vardecl :: VAR ID COLON TYPE EQ expr"),
            new("vardecl :: VAR ID COLON ID"),  //for user-defined types
            new("vardecl :: VAR ID COLON ID EQ expr"),  //for user-defined types

        });

    }
}

}