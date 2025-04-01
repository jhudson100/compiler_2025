
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
                    SymbolTable.declareGlobal( n["ID"].token, new FunctionNodeType() );
                },           
                setNodeTypes: (n) => {
                    
                    SymbolTable.enterFunctionScope();

                    foreach(TreeNode c in n.children){
                        c.setNodeTypes();
                    }

                    n.numLocals = SymbolTable.numLocals;

                    SymbolTable.leaveFunctionScope();
                    
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

                    foreach(TreeNode c in n.children){
                        c.setNodeTypes();
                    }

                    SymbolTable.leaveLocalScope();
             

                }
            ),
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
            new("stmt :: assign | cond | loop | vardecl | return | break | continue"),

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

            new( "continue :: CONTINUE"),

            new("assign :: expr EQ expr",
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
            new("cond :: IF LPAREN expr RPAREN braceblock"),
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
            new("loop :: REPEAT braceblock UNTIL LPAREN expr RPAREN"),
            
            
            new("return :: RETURN expr",
                generateCode: (n) => {

                    Asm.add(new OpComment( 
                            $"Return at line {n.children[0].token.line}"));
                    n["expr"].generateCode();   //leaves value on top of stack

                    //ABI says return values come back in rax
                    Asm.add( new OpPop(Register.rax,null));
                    Utils.epilogue(n["RETURN"].token);
                }
            ),
            new("return :: RETURN",
                generateCode: (n) => {
                    Utils.epilogue(n["RETURN"].token);
                }
            ),


            new("vardecl :: VAR ID COLON TYPE",
                setNodeTypes:(n) => {
                    var t = NodeType.tokenToNodeType(n["TYPE"].token) ;
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
            new("vardecl :: VAR ID COLON ID"),  //for user-defined types
            new("vardecl :: VAR ID COLON ID EQ expr"),  //for user-defined types

        });

    }
}

}