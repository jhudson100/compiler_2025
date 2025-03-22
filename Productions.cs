
namespace lab{

public class Productions{
    public static void makeThem(){
        Grammar.defineProductions( new PSpec[] {
            new("S :: sum SEMI"),
            new("sum :: sum PLUS prod | prod"),
            new("prod :: prod MUL factor | factor"),
            new("factor :: NUM | LPAREN sum RPAREN")
        });
        
    }
}

}