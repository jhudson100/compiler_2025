
namespace lab{

public class ProductionsExpr{

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
                }
            ),
            new("orexp :: andexp"),

            //boolean AND
            new("andexp :: andexp ANDOP relexp",
                setNodeTypes: (n) => {
                    binary(n,NodeType.Bool,NodeType.Bool);
                }
            ),
            new("andexp :: relexp"),

            //relational: x>y
            new("relexp :: bitexp RELOP bitexp",
                setNodeTypes: (n) => {
                    binary(n,
                        new NodeType[]{NodeType.Int,NodeType.Float,NodeType.String},
                        NodeType.Bool
                    );
                }),
            new("relexp :: bitexp"),

            //bitwise: or, and, xor
            new("bitexp :: bitexp BITOP shiftexp",
                setNodeTypes: (n) => {
                    binary(n,NodeType.Int,NodeType.Int);
                }),
            new("bitexp :: shiftexp"),

            new("shiftexp :: shiftexp SHIFTOP sumexp",
                setNodeTypes: (n) => {
                    binary(n,NodeType.Int,NodeType.Int);
                }),
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
                }
            ),
            new("unaryexp :: ADDOP unaryexp",
                setNodeTypes: (n) => {
                    unary(n,new NodeType[]{NodeType.Int,NodeType.Float},null);
                }
            ),
            new("unaryexp :: NOTOP unaryexp",
                setNodeTypes: (n) => {
                    unary(n,NodeType.Bool,NodeType.Bool);
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
            new("amfexp :: amfexp LPAREN calllist RPAREN"),
            new("amfexp :: factor"),

            //indivisible atom
            new("factor :: NUM",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Int;
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
                }
            ),
            new("factor :: FNUM",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Float;
                }
            ),
            new("factor :: STRINGCONST",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.String;
                }
            ),
            new("factor :: BOOLCONST",
                setNodeTypes: (n) => {
                    n.nodeType = NodeType.Bool;
                }
            ),

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
