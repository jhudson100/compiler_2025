
namespace lab{

public class ProductionsExpr{

    static void binaryOp( TreeNode n, Opcode op, IntRegister whatPush=null){
        if(whatPush == null )
            whatPush = Register.rax;
        Asm.add(new OpComment($"Binary operation {n.children[1].sym} at line {n.children[1].token.line}"));
        n.children[0].generateCode();
        n.children[2].generateCode();
        Asm.add(new OpPop(Register.rcx, null));
        Asm.add(new OpPop(Register.rax, null));
        Asm.add( op );
        Asm.add( new OpPush( whatPush, StorageClass.PRIMITIVE));
        Asm.add(new OpComment($"End of binary operation {n.children[1].sym} at line {n.children[1].token.line}"));
    }

    static void binaryOpF( TreeNode n, Opcode op){
        Asm.add(new OpComment($"Binary operation {n.children[1].sym} at line {n.children[1].token.line}"));
        n.children[0].generateCode();
        n.children[2].generateCode();
        Asm.add(new OpPopF(Register.xmm1, null));
        Asm.add(new OpPopF(Register.xmm0, null));
        Asm.add( op );
        Asm.add( new OpPushF( Register.xmm0, StorageClass.PRIMITIVE));
        Asm.add(new OpComment($"End of binary operation {n.children[1].sym} at line {n.children[1].token.line}"));
    }

    static void unaryOp( TreeNode n, Opcode op){
        Asm.add(new OpComment($"unary operation {n.children[0].sym} at line {n.children[0].token.line}"));
        n.children[1].generateCode();
        Asm.add(new OpPop(Register.rax, null));
        Asm.add( op );
        Asm.add( new OpPush( Register.rax, StorageClass.PRIMITIVE ));
        Asm.add(new OpComment($"End of unary operation {n.children[0].sym} at line {n.children[0].token.line}"));
    }

    static void unaryOpF( TreeNode n, Opcode op){
        Asm.add(new OpComment($"unary operation {n.children[0].sym} at line {n.children[0].token.line}"));
        n.children[1].generateCode();
        Asm.add(new OpPopF(Register.xmm0, null));
        Asm.add( op );
        Asm.add( new OpPushF( Register.xmm0, StorageClass.PRIMITIVE ));
        Asm.add(new OpComment($"End of unary operation {n.children[0].sym} at line {n.children[0].token.line}"));
    }


    static void unary(TreeNode n, NodeType[] operandTypes, NodeType resultType){
        foreach(var c in n.children)
            c.setNodeTypes();
        if( resultType == null )
            n.nodeType = n.children[1].nodeType;
        else
            n.nodeType = resultType;
        foreach(var t in operandTypes){
            if( n.children[1].nodeType == t )
                return;
        }
        Utils.error(n.children[0].token,$"Bad type for operation: {n.children[1].nodeType}");
    }

    static void unary(TreeNode n, NodeType operandType, NodeType resultType){
        unary(n,new NodeType[]{operandType}, resultType);
    }

    static void binary(TreeNode n, NodeType[] operandTypes, NodeType resultType){
        foreach(var c in n.children)
            c.setNodeTypes();
        if( n.children[0].nodeType != n.children[2].nodeType )
            Utils.error(n.children[1].token, $"Different types: {n.children[0].nodeType} and {n.children[2].nodeType}");
        if( resultType == null )
            n.nodeType = n.children[0].nodeType;
        else
            n.nodeType = resultType;
        foreach(var t in operandTypes){
            if( n.children[0].nodeType == t )
                return;
        }
        Utils.error(n.children[1].token,$"Bad type for operation: {n.children[0].nodeType}");
    }

    static void binary(TreeNode n, NodeType operandType, NodeType resultType){
        binary(n,new[]{operandType},resultType);
    }

    public static void makeThem(){

        Grammar.defineProductions( new PSpec[] {

            //convenience: Starts the whole expression hierarchy
            new("expr :: orexp"),

            //boolean OR
            new("orexp :: orexp OROP andexp",
                setNodeTypes: (n) => {
                    binary(n,NodeType.Bool,NodeType.Bool);
                },
                generateCode: (n) => {
                    n["orexp"].generateCode();
                    var end = new Label($"end of orexp at line {n["OROP"].token.line}");
                    Asm.add( new OpMov( Register.rsp, 8, Register.rax ) );
                    Asm.add( new OpJmpIfNonzero( Register.rax, end ) );
                    Asm.add( new OpAdd( Register.rsp, 16 ) );
                    n["andexp"].generateCode();
                    Asm.add(new OpLabel(end));
                }
            ),
            new("orexp :: andexp"),

            //boolean AND
            new("andexp :: andexp ANDOP relexp",
                setNodeTypes: (n) => {
                    binary(n,NodeType.Bool,NodeType.Bool);
                },
                generateCode: (n) => {
                    //this is going to leave the result
                    //on top of the stack
                    n["andexp"].generateCode();

                    var endexp = new Label($"end of and expr at line {n["ANDOP"].token.line}");
                    //look on top of stack and if it is zero,
                    //skip over relexp
                    Asm.add( new OpComment( "See if result of first and operand was false"));
                    Asm.add( new OpMov( Register.rsp, 8, Register.rax) );
                    Asm.add( new OpJmpIfZero(Register.rax, endexp) );

                    //discard two items from stack
                    Asm.add( new OpAdd( Register.rsp, 16 ));
                    n["relexp"].generateCode();
                    Asm.add( new OpLabel( endexp ) );
                }
            ),
            new("andexp :: relexp"),

            //relational: x>y
            new("relexp :: bitexp RELOP bitexp",
                setNodeTypes: (n) => {
                    binary(n,
                        new NodeType[]{NodeType.Int,NodeType.Float,NodeType.String,NodeType.Bool},
                        NodeType.Bool
                    );
                    if( n.children[0].nodeType == NodeType.Bool){
                        switch(n["RELOP"].token.lexeme){
                            case "==":
                            case "!=":
                                break;
                            default:
                                Utils.error(n["RELOP"],"Cannot do this comparison with booleans");
                                break;  //bogus
                        }
                    }
                },
                generateCode: (n) => {
                    n.children[0].generateCode();
                    n.children[2].generateCode();
                    if( n.children[0].nodeType == NodeType.Int ||
                        n.children[0].nodeType == NodeType.Bool){
                            string cmp;
                            switch(n["RELOP"].token.lexeme){
                                case "==": cmp="e"; break;
                                case "!=": cmp="ne"; break;
                                case ">=": cmp="ge"; break;
                                case ">": cmp="g"; break;
                                case "<=": cmp="le"; break;
                                case "<": cmp="l"; break;
                                default: throw new Exception();
                            }
                            Asm.add( new OpPop(Register.rbx,null));
                            Asm.add( new OpPop(Register.rax,null));
                            Asm.add( new OpCmp(Register.rax, Register.rbx));
                            Asm.add( new OpSetCC(cmp,Register.rax));
                            Asm.add( new OpPush(Register.rax, StorageClass.PRIMITIVE));
                    } else if( n.children[0].nodeType == NodeType.Float) {
                        string cmp;
                        switch(n["RELOP"].token.lexeme){
                            case "==": cmp="eq"; break;
                            case "!=": cmp="neq"; break;
                            case ">=": cmp="nlt"; break;
                            case ">": cmp="nle"; break;
                            case "<=": cmp="le"; break;
                            case "<": cmp="lt"; break;
                            default: throw new Exception();
                        }
                        Asm.add( new OpPopF(Register.xmm1,null));
                        Asm.add( new OpPopF(Register.xmm0,null));
                        Asm.add( new OpCmpF(cmp,Register.xmm0, Register.xmm1));
                        Asm.add( new OpMov( Register.xmm0, Register.rax));
                        Asm.add( new OpAnd(Register.rax, 1));
                        Asm.add( new OpPush(Register.rax, StorageClass.PRIMITIVE));
                    } else {
                        Console.WriteLine("Bad node type:" +n.nodeType);
                        throw new NotImplementedException();
                    }
                }
            ),
            new("relexp :: bitexp"),

            //bitwise: or, and, xor
            new("bitexp :: bitexp BITOP shiftexp",
                setNodeTypes: (n) => {
                    binary(n,NodeType.Int,NodeType.Int);
                },
                generateCode: (n) => {
                    switch( n["BITOP"].token.lexeme){
                        case "&":  binaryOp( n,new OpAnd(Register.rax,Register.rcx)); break;
                        case "|":  binaryOp( n,new OpOr(Register.rax,Register.rcx)); break;
                        case "^":  binaryOp( n, new OpXor(Register.rax,Register.rcx)); break;
                    }
                }
            ),
            new("bitexp :: shiftexp"),

            new("shiftexp :: shiftexp SHIFTOP sumexp",
                setNodeTypes: (n) => {
                    binary(n,NodeType.Int,NodeType.Int);
                },
                generateCode: (n) => {
                    switch(n["SHIFTOP"].token.lexeme){
                        case "<<":
                            binaryOp( n, new OpShl(Register.rax, Register.rcx)); break;
                        case ">>":
                            binaryOp( n, new OpShr(Register.rax, Register.rcx)); break;
                    }
                }
            ),
            new("shiftexp :: sumexp"),

            //addition and subtraction
            new("sumexp :: sumexp ADDOP prodexp",
                setNodeTypes: (n) => {
                    foreach(var c in n.children){
                        c.setNodeTypes();
                    }
                    binary( n, 
                        new NodeType[]{NodeType.Int, NodeType.Float, NodeType.String},
                        null
                    );
                    if( n.children[0].nodeType == NodeType.String && n["ADDOP"].token.lexeme != "+" )
                        Utils.error(n.children[0].token,"Cannot subtract strings");
                },
                generateCode: (n) => {
                    if( n.nodeType == NodeType.Int){
                        switch(n["ADDOP"].token.lexeme){
                            case "+": binaryOp( n, new OpAdd( Register.rax, Register.rcx)); break;
                            case "-": binaryOp( n, new OpSub( Register.rax, Register.rcx)); break;
                            default: throw new Exception();
                        }
                    } else if(n.nodeType == NodeType.Float){
                        switch(n["ADDOP"].token.lexeme){
                            case "+": binaryOpF( n, new OpAddF( Register.xmm0, Register.xmm1)); break;
                            case "-": binaryOpF( n, new OpSubF( Register.xmm0, Register.xmm1)); break;
                            default: throw new Exception();
                        }
                    } else {
                        throw new NotImplementedException();

                    }
                }
            ),
            new("sumexp :: prodexp"),

            //multiplication, division, modulo
            new("prodexp :: prodexp MULOP powexp",
                setNodeTypes: (n) => {
                    binary(n,
                        new NodeType[]{NodeType.Int, NodeType.Float},
                        null
                    );
                },
                generateCode: (n) => {
                    if( n.nodeType == NodeType.Int){
                        switch(n["MULOP"].token.lexeme){
                            case "*": binaryOp( n, new OpMul( Register.rax, Register.rcx)); break;
                            case "/": binaryOp( n, new OpDiv( Register.rax, Register.rcx)); break;
                            case "%": binaryOp( n, new OpDiv( Register.rax, Register.rcx), Register.rdx); break;
                            default: throw new Exception();
                        }
                    } else if( n.nodeType == NodeType.Float){
                        switch(n["MULOP"].token.lexeme){
                            case "*": binaryOpF( n, new OpMulF( Register.xmm0, Register.xmm1)); break;
                            case "/": binaryOpF( n, new OpDivF( Register.xmm0, Register.xmm1)); break;
                            case "%": Utils.error(n["MULOP"].token, "Modulo is not allowed on floats"); break;
                            default: throw new Exception();
                        }
                    } else {
                        throw new NotImplementedException();
                    }
                }
            ),
            new("prodexp :: powexp"),

            //exponentiation
            new("powexp :: unaryexp POWOP powexp"),
            new("powexp :: unaryexp"),

            //bitwise not, negation, unary plus
            new("unaryexp :: BITNOTOP unaryexp",
                setNodeTypes: (n) => {
                    unary(n,NodeType.Int,NodeType.Int);
                },
                generateCode: (n) => {
                    unaryOp(n, new OpNot(Register.rax));
                }
            ),
            new("unaryexp :: ADDOP unaryexp",
                setNodeTypes: (n) => {
                    unary(n,new NodeType[]{NodeType.Int,NodeType.Float},null);
                },
                generateCode: (n) => {
                    if( n.nodeType == NodeType.Int){
                        switch(n["ADDOP"].token.lexeme){
                            case "+": n.children[1].generateCode(); break;
                            case "-": unaryOp(n, new OpNeg(Register.rax)); break;
                            default: throw new Exception();
                        }
                    } else if( n.nodeType == NodeType.Float ){
                        switch(n["ADDOP"].token.lexeme){
                            case "+": n.children[1].generateCode(); break;
                            case "-": unaryOpF(n, new OpNegF(Register.xmm0,Register.xmm1)); break;
                            default: throw new Exception();
                        }
                    } else {
                        throw new NotImplementedException();
                    }
                }
            ),
            new("unaryexp :: NOTOP unaryexp",
                setNodeTypes: (n) => {
                    unary(n,NodeType.Bool,NodeType.Bool);
                },
                generateCode: (n) => {
                    n["unaryexp"].generateCode();
                    Asm.add( new OpPop(Register.rax,null));
                    //change 0->1 and 1->0
                    Asm.add( new OpXor(Register.rax,1));
                    Asm.add( new OpPush( Register.rax, StorageClass.PRIMITIVE));
                }
            ),
            new("unaryexp :: preincexp"),

            //preincrement, predecrement
            new("preincexp :: PLUSPLUS preincexp"),
            new("preincexp :: postincexp"),

            //postincrement, postdecrement
            new("postincexp :: postincexp PLUSPLUS"),
            new("postincexp :: amfexp"),

            //array, member, function call
            new("amfexp :: amfexp DOT factor"),
            new("amfexp :: amfexp LBRACKET expr RBRACKET"),
            new("amfexp :: amfexp LPAREN calllist RPAREN",
                setNodeTypes: (n) => {
                    foreach(var c in n.children){
                        c.setNodeTypes();
                    }

                    List<NodeType> ptypes = new();  //parameter types
                    Utils.walk( n["calllist"], (TreeNode c) => {
                        if( c.sym == "expr" )
                            ptypes.Add(c.nodeType);
                        if( c.sym == "amfexp" &&  c.children.Count > 1 )
                            return false;       //don't do subtree (nested
                                                //function call or array)
                        else
                            return true;
                    });


                    var ftype = n.children[0].nodeType as FunctionNodeType;
                    if( ftype == null ){
                        Utils.error(n["LPAREN"].token,
                            "Cannot call a non-function"
                        );
                    }

                    n.nodeType = ftype.returnType;

                    if( ftype.paramTypes.Count != ptypes.Count ){
                        Utils.error(n["LPAREN"].token,
                            $"Parameter count mismatch: Expected {ftype.paramTypes.Count} but got {ptypes.Count}"
                        );
                    }

                    for(int i=0;i<ftype.paramTypes.Count;i++){
                        throw new NotImplementedException("FINISH ME");
                    }
                },
                generateCode: (n) => {
                    n["callist"].generateCode();
                    //parameters are now on stack, from right to left

                    //find out where in memory the function code lives
                    n.children[0].pushAddressToStack();

                    //get the address where the function lives to rax
                    Asm.add( new OpPop( Register.rax, null));

                    var ftype = n.children[0].nodeType as FunctionNodeType;

                    if( ftype.builtin ){
                        //C ABI expects first parameter to come in via rcx
                        //we're sending the address of the stack to C
                        Asm.add( new OpMov( Register.rsp, Register.rcx));
                    }

                    Asm.add( new OpCall( Register.rax, 
                        $"function call at line {n["LPAREN"].token.line}"));
                    Asm.add( new OpAdd( Register.rsp, ftype.paramTypes.Count * 16 ));
                    //function return value came back in rax
                    //rbx holds storage class if it's not a C function
                    if( ftype.returnType != NodeType.Void ){
                        if( ftype.builtin ){
                            Asm.add(new OpPush( Register.rax, StorageClass.PRIMITIVE ));
                        } else {
                            Asm.add(new OpPush( Register.rax, Register.rbx ));
                        }
                    }
                }
            ),
            new("amfexp :: factor"),

            //indivisible atom
            new("factor :: NUM",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Int;
                },
                generateCode: (n) => {
                    long v = Int64.Parse(n["NUM"].token.lexeme);
                    Asm.add(new OpMov(v,Register.rax,""));
                    Asm.add(new OpPush(Register.rax,StorageClass.PRIMITIVE));
                }
            ),
            new("factor :: LPAREN expr RPAREN",
                setNodeTypes: (n) => {
                    foreach(var c in n.children )
                        c.setNodeTypes();
                    n.nodeType = n["expr"].nodeType;
                }
            ),
            new("factor :: ID",
                setNodeTypes: (n) => {
                    var tok = n.children[0].token;
                    var vi =  SymbolTable.lookup(tok);
                    n["ID"].varInfo = vi;
                    n["ID"].nodeType = n.nodeType = vi.type;
                },
                generateCode: (n) => {
                     n["ID"].varInfo.location.pushValueToStack(Register.rax, Register.rbx);
                },
                pushAddressToStack: (n) => {
                    n["ID"].varInfo.location.pushAddressToStack(Register.rax);
                }
            ),
            new("factor :: FNUM",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Float;
                },
                generateCode: (n) => {
                    string s = n["FNUM"].token.lexeme;
                    double value = Double.Parse(s);
                    long ivalue = BitConverter.DoubleToInt64Bits(value);
                    Asm.add( new OpMov(ivalue, Register.rax, comment: $"{s}"));
                    Asm.add( new OpPush(Register.rax, StorageClass.PRIMITIVE));
                }
            ),

            new("factor :: STRINGCONST",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.String;
                },
                generateCode: (n) => {
                    throw new NotImplementedException();
                }

            ),
            new("factor :: BOOLCONST",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Bool;
                },
                generateCode: (n) => {
                    int v;
                    switch(n["BOOLCONST"].token.lexeme){
                        case "true":    v=1; break;
                        case "false":   v=0; break;
                        default: throw new Exception();
                    }
                    Asm.add(new OpMov(v,Register.rax,n["BOOLCONST"].token.lexeme));
                    Asm.add(new OpPush(Register.rax,StorageClass.PRIMITIVE));
                }
            ),

            //function call
            //calllist = zero or more arguments
            //calllist2 = 1 or more arguments
            new("calllist :: lambda"),
            new("calllist :: calllist2"),
            new("calllist2 :: expr"),
            new("calllist2 :: calllist2 COMMA expr",
                generateCode: (n) => {
                    //right to left
                    n["expr"].generateCode();
                    n["calllist2"].generateCode();
                }
            )

        });

    }
}
}
