
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            new(@"S :: expr"),
            new(@"expr :: sum"),
            new(@"sum :: sum ADDOP prod | prod"),
            new(@"prod :: prod MULOP factor | factor"),
            new(@"factor :: NUM | ID | LPAREN expr RPAREN")
        } //end new PSpec
        );//end Grammar.defineProductions()
    }//end makeThem()
} //end class Productions

} //namespace
