
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            new("S :: decls"),
            new("decls :: funcdecl decls | classdecl decls | vardecl decls | SEMI decls | lambda"),
            new("funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI",
                collectFunctionNames: (n) => {
                    string funcName = n.children[1].token.lexeme;
                    SymbolTable.declareGlobal(n["ID"].token, new FunctionNodeType());
                },
                setNodeTypes: (n) => {
                    SymbolTable.enterFunctionScope();
                    n["optionalPdecls"].setNodeTypes();
                    n["stmts"].setNodeTypes();

                    SymbolTable.leaveFunctionScope();
                },
                generateCode: (n) => {
                    var loc = SymbolTable.lookup(n["ID"].token).location as GlobalLocation;
                    Asm.add(new OpLabel( loc.lbl ));
                    n["stmts"].generateCode();
                }
            ),
            new("braceblock :: LBRACE stmts RBRACE",
                setNodeTypes: (n) => {
                    SymbolTable.enterLocalScope();
                    foreach(var c in n.children)
                        c.setNodeTypes();
                    SymbolTable.leaveLocalScope();
                }
            ),
            new("optionalReturn :: lambda | COLON TYPE"),
            new("optionalSemi :: lambda | SEMI"),
            new("optionalPdecls :: lambda | pdecls"),
            new("pdecls :: pdecl | pdecl COMMA pdecls"),
            new("pdecl :: ID COLON TYPE",
                setNodeTypes: (n) => {
                    SymbolTable.declareParameter(
                        n["ID"].token,
                        NodeType.tokenToNodeType(n["TYPE"].token)
                    );
                }
            ),
            new("classdecl :: CLASS ID LBRACE memberdecls RBRACE SEMI",
                collectClassNames: (TreeNode n) => {
                    string className = n.children[1].token.lexeme;
                    //Console.WriteLine($"CLASS: {className}");
                    //assuming no nested classes; no need to walk
                    //children of n
                }
            ),
            new("memberdecls :: lambda | SEMI memberdecls | membervardecl memberdecls | memberfuncdecl memberdecls"),
            new("membervardecl :: VAR ID COLON TYPE SEMI"),
            new("memberfuncdecl :: funcdecl"),

            new("stmts :: stmt SEMI stmts"),
            new("stmts :: SEMI"),
            new("stmts :: lambda"),
            new("stmt :: assign | cond | loop | vardecl | return"),
            new("assign :: expr EQ expr",
                setNodeTypes: (n) => {
                    n.children[0].setNodeTypes();
                    n.children[2].setNodeTypes();
                    if( n.children[0].nodeType != n.children[2].nodeType){
                        Utils.error(n["EQ"].token,$"Type mismatch in assign: {n.children[0].nodeType} vs {n.children[2].nodeType}");
                    }
                },
                generateCode: (n) => {
                    throw new NotImplementedException();
                }
            ),
            new("cond :: IF LPAREN expr RPAREN braceblock"),
            new("cond :: IF LPAREN expr RPAREN braceblock ELSE braceblock"),
            new("loop :: WHILE LPAREN expr RPAREN braceblock"),
            new("loop :: REPEAT braceblock UNTIL LPAREN expr RPAREN"),
            new("return :: RETURN expr",
                generateCode: (n) => {
                    n["expr"].generateCode();
                    Asm.add(new OpPop(Register.rax, null));
                    Asm.add( new OpRet());
                }),
            new("return :: RETURN",
                generateCode: (n) => {
                    Asm.add( new OpRet());
                }
            ),
            new("vardecl :: VAR ID COLON TYPE",
                setNodeTypes: (n) => {
                    var tok = n["ID"].token;
                    var typ = NodeType.tokenToNodeType(n["TYPE"].token);
                    if( SymbolTable.currentlyInGlobalScope() )
                        SymbolTable.declareGlobal(tok,typ);
                    else
                        SymbolTable.declareLocal(tok,typ);
                }
            ),
            new("vardecl :: VAR ID COLON TYPE EQ expr"),
            new("vardecl :: VAR ID COLON ID"),  //for user-defined types
            new("vardecl :: VAR ID COLON ID EQ expr"),  //for user-defined types

        });

    }
}

}