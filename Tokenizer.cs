

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

        //consume leading whitespace
        while( this.index < this.input.Length && Char.IsWhiteSpace( this.input[this.index] ) ){
            //TODO: Implicit semicolon insertion
            if( this.input[this.index] == '\n' )
                this.line++;
            this.index++;
        }

        //If we've exhausted the input, return EOF
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
                if( lexeme == null || M.Groups[0].Value.Length > lexeme.Length ){
                    sym = t.sym;
                    lexeme = M.Groups[0].Value;
                }
            }
        }

        if( sym == null ){
            //print error message
            Console.WriteLine("Error at line "+this.line);
            Environment.Exit(1);
        }

        var tok = new Token( sym , lexeme, line);
        if( verbose ){
            Console.WriteLine("GOT TOKEN: "+tok);
        }

        foreach(var c in lexeme){
            if( c == '\n' )
                this.line++;
        }
        
        this.index += lexeme.Length;


        //FIXME: Do maintenance on nesting stack
        // if LPAREN or LBRACKET: push to stack
        // if RPAREN or RBRACKET: pop from stack (first do checks!)
        
        //FIXME: update my 'last token' data: Either store the token
        //itself or just store its sym or just store a bool
        //that says if it's in the eligible for implicit semis
        

        if( sym == "COMMENT" ){
            return this.next();
        } else {       
            return tok;
        }
    }//next()

} //class Tokenizer

} //namespace