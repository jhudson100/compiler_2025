
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            new("S :: decls"),
            new("decls :: funcdecl decls | classdecl decls | vardecl decls | SEMI decls | lambda"),
            new("funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI",
                collectFunctionNames: (n) => {

                    foreach(var c in n.children){
                        c.collectFunctionNames();
                    }

                    n["optionalReturn"].setNodeTypes();
                    var returnType = n["optionalReturn"].nodeType;

                    string funcName = n.children[1].token.lexeme;

                    List<NodeType> argTypes = new();

                    var ptypes = new List<NodeType>();
                    Utils.walk(n["optionalPdecls"], (c) => {
                        if( c.sym == "pdecl" ){
                            ptypes.Add( NodeType.tokenToNodeType( c["TYPE"].token ));
                            return false;
                        }
                        return true;
                    });

                    var ftype = new FunctionNodeType(
                        returnType,argTypes,false
                    );
                    n.nodeType = ftype;
                    SymbolTable.declareGlobal(n["ID"].token, ftype);
                    foreach(var c in n.children ){
                        c.collectFunctionNames();
                    }

                    SymbolTable.declareGlobal(n["ID"].token, new FunctionNodeType(rtype,ptypes));
                },
                setNodeTypes: (n) => {
                    SymbolTable.enterFunctionScope();
                    foreach(var c in n.children ){
                        c.setNodeTypes();
                    }
                    n.numLocals = SymbolTable.numLocals;
                    n.locals = new();
                    n.locals.AddRange( SymbolTable.localTypes );
                    SymbolTable.leaveFunctionScope();
                },
                returnCheck: (n) => {
                    foreach(var c in n.children){
                        c.returnCheck();
                    }
                    var ftype = n.nodeType as FunctionNodeType;
                    if( ftype.returnType != NodeType.Void ){
                        if( n["stmts"].returns == false ){
                            Utils.error(n["FUNC"].token,
                                "Non-void function might not return"
                            );
                        }
                    }
                },
                generateCode: (n) => {
                    VarInfo vi = SymbolTable.lookup(n["ID"].token); //lookup the function that we're in
                    var loc = vi.location as GlobalLocation;
                    Asm.add( new OpLabel(loc.lbl));
                    Asm.add( new OpPush( Register.rbp, StorageClass.NO_STORAGE_CLASS));
                    Asm.add( new OpMov( src: Register.rsp, dest: Register.rbp));

                    foreach(var tmp in n.locals){
                        string name = tmp.Item1;
                        NodeType typ = tmp.Item2;
                        if( typ as StringNodeType == null ){
                            Asm.add( new OpComment( name ) );
                            Asm.add( new OpMov( 0, Register.rax ) );
                        } else {
                            Asm.add( new OpComment( name ) );
                            Asm.add( new OpMov(new Label("emptyString","emptyString"), Register.rax) );
                        }
                        Asm.add( new OpPush( Register.rax, StorageClass.PRIMITIVE ) );
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
                        NodeType.typeFromToken(n["TYPE"].token)
                    );
                }
            ),
            new("classdecl :: CLASS ID LBRACE memberdecls RBRACE SEMI",
                collectClassNames: (TreeNode n) => {
                    string className = n.children[1].token.lexeme;
                    //Console.WriteLine($"CLASS: {className}");
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

            new("stmt :: assign | cond | loop | vardecl | return | break | continue",
                generateCode: (n) => {
                    Asm.add(new OpComment($"begin statement {n.children[0].sym} at line {n.firstToken().line}"));
                    foreach(var c in n.children)
                        c.generateCode();
                    Asm.add(new OpComment($"end statement {n.children[0].sym} at line {n.lastToken().line}"));
                }
            ),

            new( "break :: BREAK",
                generateCode: (n) => {
                    TreeNode x = n;
                    while( x != null && x.sym != "loop" ){
                        x=x.parent;
                    }
                    if( x == null ){
                        Utils.error(n["BREAK"].token, "Break not inside a loop");
                    }
                    Asm.add( new OpJmp( x.loopExit ));
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

            new("stmt :: expr",
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
                    Asm.add( new OpMov( src: Register.rbx, Register.rcx, 0));
                    Asm.add( new OpMov( src: Register.rax, Register.rcx, 8));
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
                    var elseLabel = new Label($"else at line {n["ELSE"].token.line}");
                    var endifLabel = new Label($"end of if starting at line {n["IF"].token.line}");

                    //make code for expr; leave result on stack
                    n["expr"].generateCode();

                    //get result into rax, discard storage class
                    Asm.add(new OpPop(Register.rax, null));
                    Asm.add( new OpJmpIfZero( Register.rax, elseLabel));
                    n.children[4].generateCode();
                    Asm.add( new OpJmp( endifLabel ));
                    Asm.add( new OpLabel( elseLabel ));
                    n.children[6].generateCode();
                    Asm.add( new OpLabel( endifLabel));
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
                    int line = n["WHILE"].token.line;
                    var topLoop = new Label($"top of while loop at line {line}");
                    var bottomLoop = new Label($"end of while loop at line {line}");

                    n.loopExit = bottomLoop;
                    n.loopTest = topLoop;

                    Asm.add( new OpLabel(topLoop));
                    n["expr"].generateCode();
                    Asm.add( new OpPop( Register.rax, null));
                    Asm.add( new OpJmpIfZero( Register.rax, bottomLoop));
                    n["braceblock"].generateCode();
                    Asm.add( new OpJmp( topLoop));
                    Asm.add( new OpLabel( bottomLoop));
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
                    TreeNode p = n;
                    while( p.sym != "funcdecl" ){
                        p=p.parent;
                    }
                    //funcdecl :: FUNC ID LPAREN optionalPdecls RPAREN optionalReturn LBRACE stmts RBRACE SEMI
                    var retType = p["optionalReturn"].nodeType;
                    var gotType = n["expr"].nodeType ;
                    if( gotType != retType ){
                        Utils.error(n["RETURN"].token,
                            $"Return type mismatch: Expected {retType} but got {gotType}"
                        );
                    }

                },
                generateCode: (n) => {
                    Asm.add(new OpComment(
                            $"Return at line {n.children[0].token.line}"));
                    n["expr"].generateCode();   //leaves value on top of stack

                    //ABI says return values come back in rax
                    //our code expects storage class to come back
                    //in rbx
                    Asm.add( new OpPop(Register.rax,Register.rbx));
                    Utils.epilogue(n["RETURN"].token);
                }),
            new("return :: RETURN",
                setNodeTypes: (n) => {
                    throw new NotImplementedException();
                },
                generateCode: (n) => {
                    Utils.epilogue(n["RETURN"].token);
                }
            ),
            new("vardecl :: VAR ID COLON TYPE",
                setNodeTypes:(n) => {
                    var t = NodeType.typeFromToken(n["TYPE"].token) ;
                    if( SymbolTable.currentlyInGlobalScope()){
                        SymbolTable.declareGlobal( n["ID"].token, t);
                    } else {
                        SymbolTable.declareLocal( n.children[1].token, t );
                    }
                }
            ),
            new("vardecl :: VAR ID COLON TYPE EQ expr",
                setNodeTypes:(n)=>{
                    n["expr"].setNodeTypes();
                    //look at expr.nodeType
                    // look at TYPE
                    throw new Exception("FINISH ME");
                }
            ),

            new("vardecl :: VAR ID COLON ID",        //for user-defined types
                setNodeTypes: (n) => {
                    throw new NotImplementedException();
                }
            ),
            new("vardecl :: VAR ID COLON ID EQ expr",       //for user-defined types
                setNodeTypes: (n) => {
                    throw new NotImplementedException();
                }
            ),

        });

    }
}

}
