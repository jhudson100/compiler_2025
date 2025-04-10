
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

                    string funcName = n.children[1].token.lexeme;


                    NodeType returnType = n["optionalReturn"].nodeType;

                    List<NodeType> argTypes = new();

                    Utils.walk( n["optionalPdecls"], (c) => {
                        //c is a tree node
                        if(c.sym == "TYPE" ){
                            argTypes.Add(NodeType.typeFromToken(c.token));
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
                },
                setNodeTypes: (n) => {
                    SymbolTable.enterFunctionScope();
                    foreach(var c in n.children ){
                        c.setNodeTypes();
                    }
                    n.numLocals = SymbolTable.numLocals;
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
                    if( n.numLocals > 0 ){
                        Asm.add( new OpSub( Register.rsp, n.numLocals*16 ));
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
            new("optionalReturn :: lambda | COLON TYPE",
                collectFunctionNames: (n) => {
                    if( n.children.Count == 0 )
                        n.nodeType = NodeType.Void;
                    else
                        n.nodeType = NodeType.typeFromToken(n["TYPE"].token);
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
            new("stmt :: assign | cond | loop | vardecl | return"),
                        new( "break :: BREAK",
                generateCode: (n) => {
                    TreeNode x = n;
                    while( x != null && x.sym != "loop" ){
                        x=x.parent;
                    }
                    if( x == null ){
                        Utils.error(n["BREAK"].token, "Break not inside a loop");
                    }
                    Asm.add( new OpJmp( x.exit ));
                }
            ),

            new("stmt :: expr",
                generateCode: (n) => {
                    n["expr"].generateCode();
                    //if result is not void, must discard values
                    if( n["expr"].nodeType != NodeType.Void ){
                        Asm.add( new OpAdd(Register.rsp,16));
                    }
                }
            ),

            new( "continue :: CONTINUE",
                generateCode: (n) => {
                    throw new NotImplementedException();
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
                    n.children[0].pushAddressToStack();
                    n.children[2].generateCode();
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
                generateCode: (n) => {
                    throw new NotImplementedException();
                }
            ),
            new("cond :: IF LPAREN expr RPAREN braceblock ELSE braceblock",
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
            generateCode: (n) => {
                    int line = n["WHILE"].token.line;
                    var topLoop = new Label($"top of while loop at line {line}");
                    var bottomLoop = new Label($"end of while loop at line {line}");

                    n.entry = topLoop; 
                    n.exit = bottomLoop;
                    n.test = topLoop;

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
                generateCode: (n) => {
                    throw new NotImplementedException();
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
            new("vardecl :: VAR ID COLON TYPE EQ expr"),
            new("vardecl :: VAR ID COLON ID"),  //for user-defined types
            new("vardecl :: VAR ID COLON ID EQ expr"),  //for user-defined types

        });

    }
}

}