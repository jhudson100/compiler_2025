
namespace lab{

public class Terminals{
    public static void makeThem(){
        Grammar.addTerminals( new Terminal[] {
            new("COMMENT",          @"//[^\n]*"),
            new("EQ",               @"="),
            new("LPAREN",           @"\("),
            new("MUL",              @"\*"),
            new("NUM",              @"\d+" ),
            new("PLUS",             @"\+"),
            new("RPAREN",           @"\)"),
            new("SEMI",             @";"),
            new("ID",               @"(?!\d)\w+" )
        });
    } //makeThem
} //class Terminals

} //namespace
