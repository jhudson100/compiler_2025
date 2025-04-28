
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            new("S :: decls"),
            new("decls :: funcdecl decls | classdecl decls | vardecl decls | SEMI decls | lambda"),
            new("funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI",
                collectFunctionNames: (n) => {
                    string funcName = n.children[1].token.lexeme;
                    n["optionalReturn"].setNodeTypes();
                    var rtype = n["optionalReturn"].nodeType;
                    var ptypes = new List<NodeType>();
                    Utils.walk(n["optionalPdecls"], (c) => {
                        if( c.sym == "pdecl" ){
                            ptypes.Add( NodeType.tokenToNodeType( c["TYPE"].token ));
                            return false;
                        }
                        return true;
                    });
                    SymbolTable.declareGlobal(n["ID"].token, new FunctionNodeType(rtype,ptypes,false));
                },
                
                returnCheck: (n) => {
                    foreach(var c in n.children)
                        c.returnCheck();
                    var rtype = n["optionalReturn"].nodeType;
                    if( rtype != NodeType.Void && !n["stmts"].returns )
                        Utils.error(n,"Function might not return");
                },

                setNodeTypes: (n) => {
                    SymbolTable.enterFunctionScope();
                    n["optionalPdecls"].setNodeTypes();
                    n["stmts"].setNodeTypes();
                    n.numLocals = SymbolTable.numLocals;
                     n.numLocals = SymbolTable.numLocals;    //should have this already
                    n.localVarTypes = new NodeType[n.numLocals];
                    n.localVarNames = new string[n.numLocals];

                    foreach( var item in SymbolTable.table ){
                        string varname = item.Key;
                        VarInfo vi = item.Value;
                        var lloc = vi.location as LocalLocation;
                        if( lloc != null ){
                            n.localVarTypes[lloc.num] = vi.type;
                            n.localVarNames[lloc.num] = varname;
                        }
                    }

                    SymbolTable.leaveFunctionScope();
                },
                generateCode: (n) => {
                    var loc = SymbolTable.lookup(n["ID"].token).location as GlobalLocation;
                    Asm.add(new OpLabel( loc.lbl ));

                    Asm.add( new OpPush( Register.rbp, StorageClass.NO_STORAGE_CLASS));
                    Asm.add( new OpMov( src: Register.rsp, dest: Register.rbp));

                    VarInfo vi = SymbolTable.lookup(n["ID"].token); //lookup the function that we're in

                    bool raxGood=false;
                    
                    Asm.add( new OpSub( Register.rsp, n.localVarTypes.Length*16));

                    for(int i=0;i<n.localVarTypes.Length;++i){
                        int sclassOffset = -16 * (i+1);
                        int valueOffset = sclassOffset+8;
                        if( n.localVarTypes[i] == NodeType.String ){
                            if(!raxGood){
                                Asm.add( new OpMov( new Label("emptyString","emptyString"), Register.rax) );
                                raxGood=true;
                            }
                            Asm.add( new OpMov( Register.rax, Register.rbp, valueOffset, n.localVarNames[i]+": value" ));
                            Asm.add( new OpMov( 0, Register.rbp, sclassOffset, n.localVarNames[i]+": storage class = primitive") );
                        } else{
                            Asm.add( new OpMov( 0, Register.rbp, valueOffset, n.localVarNames[i]+": value") );
                            Asm.add( new OpMov( 0, Register.rbp, sclassOffset, n.localVarNames[i]+": storage class = primitive") );
                        }
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
                },
                returnCheck: (n) => {
                    foreach(var c in n.children)
                        c.returnCheck();
                    if( n["stmts"].returns )
                        n.returns = true;
                }
            ),
            new("optionalReturn :: lambda",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Void;
                }
            ),
            new("optionalReturn :: COLON TYPE",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.tokenToNodeType(n["TYPE"].token);
                }
            ),
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

            new("stmts :: stmt SEMI stmts",
                returnCheck: (n) => {
                    foreach(var c in n.children)
                        c.returnCheck();
                    if( n["stmt"].returns )
                        n.returns = true;
                    if( n["stmts"].returns )
                        n.returns = true;
                }
            ),
            new("stmts :: SEMI"),
            new("stmts :: lambda"),
            new("stmt :: assign | cond | loop | vardecl | return | break | continue",
                returnCheck: (n) => {
                    foreach(var c in n.children)
                        c.returnCheck();
                    if( n.children[0].returns )
                        n.returns = true;
                },
                generateCode: (n) => {
                    Asm.add(new OpComment($"begin statement {n.children[0].sym} at line {n.firstToken().line}"));
                    foreach(var c in n.children)
                        c.generateCode();
                    Asm.add(new OpComment($"end statement {n.children[0].sym} at line {n.lastToken().line}"));
                }
            ),
            new("stmt :: expr",
                returnCheck: (n) => {
                    foreach(var c in n.children)
                        c.returnCheck();
                    if( n.children[0].returns )
                        n.returns = true;
                },
                generateCode: (n) => {
                    Asm.add(new OpComment($"begin statement {n.children[0].sym} at line {n.firstToken().line}"));
                    var c = n.children[0];
                    c.generateCode();
                    if( c.nodeType == null )
                        throw new Exception();
                    if( c.nodeType != NodeType.Void ){
                        Asm.add(new OpPop(null,null));
                    }
                    Asm.add(new OpComment($"end statement {n.children[0].sym} at line {n.lastToken().line}"));
                }
            ),
            new("assign :: expr EQ expr",
                setNodeTypes: (n) => {
                    n.children[0].setNodeTypes();
                    n.children[2].setNodeTypes();
                    if( n.children[0].nodeType as FunctionNodeType != null ){
                        Utils.error(n["EQ"].token, "Cannot assign functions");
                    }
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
                    Asm.add( new OpMov( src: Register.rbx, Register.rcx, 0, "storage class"));
                    Asm.add( new OpMov( src: Register.rax, Register.rcx, 8, "value"));
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
                returnCheck: (n) => {
                    foreach(var c in n.children)
                        c.returnCheck();
                    if( n.children[4].returns && n.children[6].returns )
                        n.returns = true;
                },
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
                setNodeTypes: (n) => {
                    foreach(var c in n.children){
                        c.setNodeTypes();
                    }
                    Utils.returnCheck(n,n["expr"].nodeType);
                },
                returnCheck: (n) => {
                    n.returns=true;
                },
                generateCode: (n) => {
                    n["expr"].generateCode();
                    Asm.add(new OpPop(Register.rax, Register.rbx));
                    Utils.epilogue(n["RETURN"].token);
                }),
            new("return :: RETURN",
                setNodeTypes: (n) => {
                    Utils.returnCheck(n, NodeType.Void);
                },
                returnCheck: (n) => {
                    n.returns=true;
                },
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
            new("vardecl :: VAR ID COLON TYPE EQ expr",
                generateCode: (n) => {
                    throw new NotImplementedException();
                }
            ),
            new("vardecl :: VAR ID COLON ID",
                generateCode: (n) => {
                    throw new NotImplementedException();
                }
            ),  //for user-defined types
            new("vardecl :: VAR ID COLON ID EQ expr",
            generateCode: (n) => {
                    throw new NotImplementedException();
                }
            ),  //for user-defined types

        });

    }
}

}