
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {

            //simple, one production
            new PSpec( "assign :: ID EQ NUM SEMI"),

            //several prod's with common lhs
            new( @"decl :: VAR ID COLON TYPE SEMI
                        |  VAR ID COLON TYPE EQ NUM SEMI
                        |  VAR ID EQ NUM SEMI
            "),

            //several prod's, same lhs, all on one line
            new("stmt :: assign| loop |cond"),

            //production split over two lines
            new( @"cond :: IF expr braceblock
                        | IF expr braceblock
                        ELSE braceblock
            "),

            new( "braceblock :: LBRACE stmts RBRACE" ),

            //lambda production
            new( " stmts::stmt SEMI stmts|lambda"),

            //nice plain vanilla productions
            new("expr :: NUM | ID | NUM ADDOP NUM"),

            //utf-8
            new( "optionalType :: λ | TYPE"),

            new( "func-call :: ID LPAREN plist RPAREN "),
            new( "plist :: param plist' | λ "),
            new( "plist' :: lambda | COMMA param plist'")
        });
        
    }
}

}