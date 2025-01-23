

using System.Text.RegularExpressions;

namespace lab{

public class Token{
    public string sym; 
    public string lexeme;
    public int line;
    public Token( string sym, string lexeme, int line){
        this.sym = sym;
        this.lexeme = lexeme;
        this.line = line;
    }
    public override string ToString()
    {
        var lex = lexeme.Replace("\\","\\\\").Replace("\"","\\\"").Replace("\n","\\n");

        return $"{{ \"sym\": \"{this.sym}\" , \"line\" : {this.line}, \"lexeme\" : \"{lex}\"  }}";
    }

}

public class Tokenizer{

    bool verbose=false;

    string input;   //stuff we are tokenizing
    int line;   //current line number
    int index;  //where we are at in the input

    Stack<Token> nesting = new();

    public Tokenizer(string inp){
        this.input = inp;
        this.line = 1;
        this.index = 0;
    }

    //we can insert an implicit semicolon after these things
    List<string> implicitSemiAfter = new(){"NUM","RPAREN"};

    public Token next(){

        if( this.index >= this.input.Length ){
            if(verbose){
                Console.WriteLine("next(): At EOF!");
            }
            return null;
        }

        String sym=null;
        String lexeme=null;
        foreach( var t in Grammar.terminals){
            Match M = t.rex.Match( this.input, this.index );
            if(verbose){
                Console.WriteLine("Trying terminal "+t.sym+ "   Matched? "+M.Success);
            }
            if( M.Success ){
                //FIXME: Need maximal munch
                sym = t.sym;
                lexeme = M.Groups[0].Value;
                break;
            }
        }

        if( sym == "WHITESPACE" && lexeme.Contains('\n') && nesting.Count == 0){
            //insert implicit semicolon depending on what 
            //the previous token was: If previous token
            //is in my list, return semi
            //don't forget to update last token returned
            return new Token("SEMI", "", this.line);
        }

        if( sym == null ){
            //print error message
            Console.WriteLine("Error at line "+this.line);
            Environment.Exit(1);
        }
        this.index += lexeme.Length;


        var tok = new Token( sym , lexeme, line);
        if( verbose ){
            Console.WriteLine("RETURNING TOKEN: "+tok);
        }

        //FIXME: adjust line number

        if( sym == "WHITESPACE" ){
            return this.next();
        }        

        //FIXME: Do maintenance on nesting stack
        // if LPAREN or LBRACKET: push to stack
        // if RPAREN or RBRACKET: pop from stack (first do checks!)
        
        //FIXME: update my 'last token' data: Either store the token
        //itself or just store its sym or just store a bool
        //that says if it's in the eligible for implicit semis
        
        return tok;
    }//next()

} //class Tokenizer

} //namespace