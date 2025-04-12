
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
            new("stmt :: assign | cond | loop | vardecl | return | break | continue"),
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
            new("break :: BREAK",
                generateCode: (n) => {
                    var p = n;
                    while(p!=null && p.sym != "loop"){
                        p = p.parent;
                    }
                    if( p == null ){
                        Utils.error(n.children[0].token, "Break not in a loop");
                    }
                    Asm.add( new OpJmp( p.loopExit ) );
                }
            ),
            new("continue :: CONTINUE",
                generateCode: (n) => {
                    var p = n;
                    while(p!=null && p.sym != "loop"){
                        p = p.parent;
                    }
                    if( p == null ){
                        Utils.error(n.children[0].token, "Continue not in a loop");
                    }
                    Asm.add( new OpJmp( p.loopTest ) );
                }
            ),
            
            new("cond :: IF LPAREN expr RPAREN braceblock",
                setNodeTypes: (n) => {
                    foreach(var c in n.children)
                        c.setNodeTypes();
                    if( n["expr"].nodeType != NodeType.Bool){
                        Utils.error(n["IF"].token, "Bad type for conditional");
                    }
                },
                generateCode: (n) => {
                    var endif = new Label($"endif for line {n["IF"].token.line}");
                    n["expr"].generateCode();
                    Asm.add(new OpPop(Register.rax,null));
                    Asm.add(new OpJmpIfZero(Register.rax,endif));
                    n["braceblock"].generateCode();
                    Asm.add(new OpLabel(endif));
                }
            ),
            new("cond :: IF LPAREN expr RPAREN braceblock ELSE braceblock",
                setNodeTypes: (n) => {
                    foreach(var c in n.children)
                        c.setNodeTypes();
                    if( n["expr"].nodeType != NodeType.Bool){
                        Utils.error(n["IF"].token, "Bad type for conditional");
                    }
                },
                generateCode: (n) => {
                    var endif = new Label($"endif for line {n["IF"].token.line}");
                    var else_ = new Label($"else for line {n["ELSE"].token.line}");
                    n["expr"].generateCode();
                    Asm.add(new OpPop(Register.rax,null));
                    Asm.add(new OpJmpIfZero(Register.rax,else_));
                    n.children[4].generateCode();
                    Asm.add(new OpJmp(endif));
                    Asm.add(new OpLabel(else_));
                    n.children[6].generateCode();
                    Asm.add(new OpLabel(endif));
                }
            ),
            new("loop :: WHILE LPAREN expr RPAREN braceblock",
                setNodeTypes: (n) => {
                    foreach(var c in n.children)
                        c.setNodeTypes();
                    if( n["expr"].nodeType != NodeType.Bool){
                        Utils.error(n["WHILE"].token, "Bad type for conditional");
                    }
                },
                generateCode: (n) => {
                    n.loopTest = new Label($"loop test for loop at {n["LPAREN"].token.line}");
                    n.loopExit = new Label($"loop exit for loop at {n["LPAREN"].token.line}");
                    Asm.add(new OpLabel(n.loopTest));
                    n["expr"].generateCode();
                    Asm.add(new OpPop(Register.rax,null));
                    Asm.add(new OpJmpIfZero(Register.rax,n.loopExit));
                    n["braceblock"].generateCode();
                    Asm.add(new OpJmp(n.loopTest));
                    Asm.add(new OpLabel(n.loopExit));
                }
            ),
            new("loop :: REPEAT braceblock UNTIL LPAREN expr RPAREN",
                setNodeTypes: (n) => {
                    foreach(var c in n.children)
                        c.setNodeTypes();
                    if( n["expr"].nodeType != NodeType.Bool){
                        Utils.error(n["LPAREN"].token, "Bad type for conditional");
                    }
                },
                generateCode: (n) => {
                    n.loopTest = new Label($"loop test for loop at {n["LPAREN"].token.line}");
                    n.loopExit = new Label($"loop exit for loop at {n["RPAREN"].token.line}");
                    var loopStart = new Label($"loop start for loop at line {n["REPEAT"].token.line}");
                    Asm.add(new OpLabel(loopStart));
                    n["braceblock"].generateCode();
                    Asm.add(new OpLabel(n.loopTest));
                    n["expr"].generateCode();
                    Asm.add(new OpPop(Register.rax,null));
                    Asm.add(new OpJmpIfZero(Register.rax,loopStart));
                    Asm.add(new OpLabel(n.loopExit));
                }
            ),
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