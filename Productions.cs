
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
                    n.numLocals = SymbolTable.numLocals;
                    SymbolTable.leaveFunctionScope();
                },
                generateCode: (n) => {
                    var loc = SymbolTable.lookup(n["ID"].token).location as GlobalLocation;
                    Asm.add(new OpLabel( loc.lbl ));

                    Asm.add( new OpPush( Register.rbp, StorageClass.NO_STORAGE_CLASS));
                    Asm.add( new OpMov( src: Register.rsp, dest: Register.rbp));

                    VarInfo vi = SymbolTable.lookup(n["ID"].token); //lookup the function that we're in
                    if( n.numLocals > 0 ){
                        Asm.add( new OpSub( Register.rsp, n.numLocals*16, $"space for {n.numLocals} locals" ));
                    }
                    n["stmts"].generateCode();
                    Utils.epilogue(n.lastToken());
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
            new("stmt :: assign | cond | loop | vardecl | return | break | continue",
                generateCode: (n) => {
                    Asm.add(new OpComment($"begin statement {n.children[0].sym} at line {n.firstToken().line}"));
                    foreach(var c in n.children)
                        c.generateCode();
                    Asm.add(new OpComment($"end statement {n.children[0].sym} at line {n.lastToken().line}"));
                }
            ),
            new("assign :: expr EQ expr",
                setNodeTypes: (n) => {
                    n.children[0].setNodeTypes();
                    n.children[2].setNodeTypes();
                    if( n.children[0].nodeType != n.children[2].nodeType){
                        Utils.error(n["EQ"].token,$"Type mismatch in assign: {n.children[0].nodeType} vs {n.children[2].nodeType}");
                    }
                },
                generateCode: (n) => {
                    Asm.add(new OpComment("Assign: Push address of lhs to stack"));
                    n.children[0].pushAddressToStack();
                    Asm.add(new OpComment("Assign: Push value of rhs to stack"));
                    n.children[2].generateCode();
                    Asm.add(new OpComment("Assign: Copy value to memory"));
                    //get the value (rhs) to rax
                    //storage class to rbx
                    Asm.add(new OpPop(Register.rax, Register.rbx));
                    //address of variable is in rcx;
                    //discard storage class (storage class of an
                    //address is 0)
                    Asm.add( new OpPop( Register.rcx, null));

                    //Write data + storage to memory
                    //Storage class first, then data
                    Asm.add( new OpMov( src: Register.rbx, Register.rcx, 0));
                    Asm.add( new OpMov( src: Register.rax, Register.rcx, 8));
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
                    Utils.epilogue(n["RETURN"].token);
                }),
            new("return :: RETURN",
                generateCode: (n) => {
                    Utils.epilogue(n["RETURN"].token);
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