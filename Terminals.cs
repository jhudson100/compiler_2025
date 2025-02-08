
namespace lab{

public class Terminals{
    public static void makeAllOfTheTerminals(){
        Grammar.addTerminals( new Terminal[] {
            new("ADDOP",            @"[-+]"),
            new("ANDOP",            @"\band\b"),
            new("ARROW",            @"->"),
            new("BITNOTOP",         @"~"),
            new("BITOP",            @"[|&^]"),
            new("BOOLCONST",        @"\b(true|false)\b"),
            new("BREAK",            @"\bbreak\b"),
            new("CLASS",            @"\bclass\b"),
            new("COLON",            @":"),
            new("COMMA",            @","),
            new("COMMENT",          @"(//[^\n]*)|(/\*(.|[\n])*?\*/)"),
            new("CONTINUE",         @"\bcontinue\b"),
            new("DOT",              @"\."),
            new("ELSE",             @"\belse\b"),
            new("EQ",               @"="),
            new("FNUM",             @"(?xi) (
                                        \d+(\.\d*)?e[+-]?\d+
                                      | \d+\.\d*
                                    )
            "),
            new("FUNC",             @"\bfunc\b"),
            new("IF",               @"\bif\b"),
            new("LBRACE",           @"\{"),
            new("LBRACKET",         @"\["),
            new("LPAREN",           @"\("),
            new("MULOP",            @"[*/%]"),
            new("NOTOP",            @"\bnot\b"),
            new("NUM",              @"\d+"),
            new("OROP",             @"\bor\b"),
            new("POWOP",            @"[*]{2}"),
            new("PLUSPLUS",         @"[+]{2}|-{2}"),
            new("RBRACE",           @"\}"),
            new("RBRACKET",         @"\]"),
            new("RELOP",            @">=|<=|!=|==|>|<"),
            new("REPEAT",           @"\brepeat\b"),
            new("RETURN",           @"\breturn\b"),
            new("RPAREN",           @"\)"),
            new("SEMI",             @";"),
            new("SHIFTOP",          @"<<|>>>|>>"),
            new("STRINGCONST",      @"(?x) "" (\\.|[^""])* ""  "),
            new("TYPE",             @"\b(int|float|string|bool)\b"),
            new("UNTIL",            @"\buntil\b"),
            new("VAR",              @"\bvar\b"),
            new("WHILE",            @"\bwhile\b"),
            new("ID",               @"(?!\d)\w+" )
        });
    } //makeThem
} //class Terminals

} //namespace
