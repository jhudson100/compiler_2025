
namespace lab{

public class ProductionsExpr{
    public static void makeThem(){

        Grammar.defineProductions( new PSpec[] {

            //convenience: Starts the whole expression hierarchy
            new("expr :: orexp"),

            //boolean OR
            new("orexp :: orexp OROP andexp"),
            new("orexp :: andexp"),

            //boolean AND
            new("andexp :: andexp ANDOP relexp"),
            new("andexp :: relexp"),

            //relational: x>y
            new("relexp :: bitexp RELOP bitexp"),
            new("relexp :: bitexp"),

            //bitwise: or, and, xor
            new("bitexp :: bitexp BITOP shiftexp"),
            new("bitexp :: shiftexp"),

            new("shiftexp :: shiftexp SHIFTOP sumexp",
                generateCode: (n) => {

                    //ex: 4 << 2

                    //ex: 4
                    n["shiftexp"].generateCode();

                    //ex: 2
                    n["sumexp"].generateCode();
    
                    Asm.add(new OpPop(Register.rcx,null));      //ex: 2
                    Asm.add(new OpPop(Register.rax,null));      //ex: 4
                    if( n["SHIFTOP"].token.lexeme == "<<" ){
                        Asm.add(new OpShl(Register.rax, Register.rcx));
                    }
                    Asm.add( new OpPush( Register.rax, StorageClass.PRIMITIVE));
                }
            ),
            new("shiftexp :: sumexp"),

            //addition and subtraction
            new("sumexp :: sumexp ADDOP prodexp",
                setNodeTypes: (n) => {
                    foreach(var c in n.children){
                        c.setNodeTypes();
                    }
                    var t1 = n["sumexp"].nodeType;
                    var t2 = n["prodexp"].nodeType;
                    var addop = n["ADDOP"].token;
                    if( t1 != t2 )
                        Utils.error(addop,$"Type mismatch for add/subtract ({t1} and {t2})");

                    
                    if( t1 != NodeType.Int && t1 != NodeType.Float && t1 != NodeType.String ){
                        n.print();
                        Utils.error(addop,$"Bad type for add/subtract ({t1})");
                    }

                    if( t1 == NodeType.String && n["ADDOP"].token.lexeme != "+" )
                        Utils.error(addop,"Cannot subtract strings");

                    n.nodeType = t1;
                }
            ),
            new("sumexp :: prodexp"),

            //multiplication, division, modulo
            new("prodexp :: prodexp MULOP powexp",
                setNodeTypes: (n) => {
                    //do stuff
                },
                generateCode: (n) => {

                    if( n.nodeType == NodeType.Int ){
                        // 5 % 3

                        //5
                        n["prodexp"].generateCode();

                        //3
                        n["powexp"].generateCode();

                        Asm.add(new OpPop( Register.rbx, null));  //3
                        Asm.add(new OpPop( Register.rax, null));  //5

                        Asm.add(new OpDiv( Register.rax, Register.rbx));
                        
                        //push remainder to stack
                        Asm.add(new OpPush( Register.rdx, StorageClass.PRIMITIVE ));
                    } else {
                        //TODO: FLOAT
                    }
                
                }
                
            ),
            new("prodexp :: powexp"),

            //exponentiation
            new("powexp :: unaryexp POWOP powexp"),
            new("powexp :: unaryexp"),

            //bitwise not, negation, unary plus
            new("unaryexp :: BITNOTOP unaryexp",
                generateCode: (n) => {
                    n["unaryexp"].generateCode();
                    Asm.add(new OpPop(Register.rax,null));
                    Asm.add(new OpNot(Register.rax));
                    Asm.add(new OpPush(Register.rax,StorageClass.PRIMITIVE));
                }
            ),
            new("unaryexp :: ADDOP unaryexp",
                generateCode: (n) => {
                    if( n["ADDOP"].token.lexeme == "+" )
                        n["unaryexp"].generateCode();
                }
            ),
            new("unaryexp :: NOTOP unaryexp"),
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
            new("amfexp :: amfexp LPAREN calllist RPAREN"),
            new("amfexp :: factor"),

            //indivisible atom
            new("factor :: NUM",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Int;
                },
                generateCode: (n) => {
                    //make code for factor
                    string s = n["NUM"].token.lexeme;
                    long value = Int64.Parse(s);
                    Asm.add( new OpMov(value, Register.rax));
                    Asm.add( new OpPush(Register.rax, StorageClass.PRIMITIVE));
                }
            ),
            new("factor :: LPAREN expr RPAREN"),

            new("factor :: ID",
                setNodeTypes: (n) => {
                    var tok = n.children[0].token;
                    VarInfo vi =  SymbolTable.lookup(tok);
                    n["ID"].varInfo = vi;
                    n["ID"].nodeType = n.nodeType = vi.type;
                }
            ),

            new("factor :: FNUM",
                setNodeTypes: (n) => {
                    throw new Exception("FINISH ME");
                },
                generateCode: (n) => {
                    //throw new Exception("FINISH ME");
                }
            ),
            new("factor :: STRINGCONST",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.String;
                }),
            new("factor :: BOOLCONST"),


            //function call
            //calllist = zero or more arguments
            //calllist2 = 1 or more arguments
            new("calllist :: lambda"),
            new("calllist :: calllist2 COMMA expr"),
            new("calllist2 :: expr"),
            new("calllist2 :: calllist2 COMMA expr")

        });

    }
}
}
