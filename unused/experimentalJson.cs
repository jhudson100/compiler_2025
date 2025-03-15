/*
namespace experimental{
    using lab;

    static class Experimental {
        public static void expectJsonOpenBrace(StreamReader r){
            expectCharacter(r,'{');
        }
        public static bool expectJsonOpenBraceOrNull(StreamReader r){
            consumeWhitespace(r);
            if( r.Peek() == '{' ){
                r.Read();
                return true;
            } else {
                expectNull(r);
                return false;
            }
        }
        
        public static void expectNull(StreamReader r){
            char[] buff = new char[4];
            r.Read(buff,0,4);
            string s = new String(buff);
            if( s != "null" )
                throw new Exception("Expected the word null");
        }

        public static void expectJsonCloseBrace(StreamReader r){
            expectCharacter(r,'}');
        }


        private static void consumeWhitespace(StreamReader r){
            while( true ){
                int c = r.Peek();
                if( c == -1 )
                    return;
                if( Char.IsWhiteSpace( (char)c) ){
                    r.Read();
                } else {
                    return;
                }
            }
        }

        //Discarding leading whitespace and look for the character 'ex'.
        //if a non-whitespace character is found before finding ex,
        //signal an error.
        private static void expectCharacter(StreamReader r, char ex){
            consumeWhitespace(r);
            int c = r.Read();
            if( c == -1 )
                throw new Exception("Early EOF");
            if( (char)c == ex ){
                return;
            } else {
                throw new Exception($"Did not find {ex}; got {(char)c}");
            }
        }

        //read and consume characters up to 'ex'.
        //Return those characters; the character ex is discarded.
        //Leading whitespace is returned.
        private static string readToCharacter(StreamReader r, char ex){
            string chars="";
            while(true){
                int c = r.Read();
                if( c == -1 ){
                    throw new Exception($"EOF reached before finding {ex}");
                } else if( (char)c == ex ){
                    return chars;
                } else {
                    chars += (char) c;
                }
            }
        }
 
        private static void readKey(StreamReader r, string key){
            consumeWhitespace(r);
            if( r.Peek() == ',' ){
                r.Read();
                consumeWhitespace(r);
            }
            expectCharacter(r,'"');
            string k = readToCharacter(r,'"');
            if( k != key ){
                throw new Exception($"Did not get expected key {key} (got {k})");
            }
            expectCharacter(r,':');
        }

        public static string expectJsonString(StreamReader r, string key){
            readKey(r,key);
            return expectJsonPlainString(r);
        }

        public static string expectJsonPlainString(StreamReader r){
            consumeWhitespace(r);
            if( r.Peek() == '"'){
                expectCharacter(r,'"');
                string s = "";
                while(true){
                    int ci = r.Read();
                    if( ci == -1 )
                        throw new Exception("Early EOF");
                    char c = (char) ci;
                    if( c == '"' ){
                        break;
                    } else if( c == '\\'){
                        char ec = (char)r.Read();
                        if( ec == '\\')
                            s += "\\";
                        else if( ec == 'n' )
                            s += "\n";
                        else if( ec == 'r' )
                            s += "\r";
                        else if( ec == '"' )
                            s += "\"";
                        else 
                            throw new Exception($"Invalid escape: \\{ec}");
                    } else {
                        s += c;
                    }
                }
                return s;
            } else {
                expectNull(r);
                return null;
            }
        }

        public static Token expectJsonToken(StreamReader r, string key){
            readKey(r,key);
            return Token.fromJson(r);
        }

        public static int expectJsonInt(StreamReader r, string key){
            readKey(r,key);
            string s = "";
            while(true){
                int ci = r.Peek();
                if( ci == -1 )
                    break;
                char c = (char) ci;
                if( c >= '0' && c <= '9' )
                    s += c;
                else    
                    break;
            }
            return Int32.Parse(s);
        }      

        public static VarInfo expectJsonVarInfo(StreamReader r, string key){
            readKey(r,key);
            return VarInfo.fromJson(r);
        }

        public static VarLocation expectJsonVarLocation(StreamReader r, string key){
            readKey(r,key);
            return VarLocation.fromJson(r);
        }

        public static NodeType expectJsonNodeType(StreamReader r, string key){
            readKey(r,key);
            return NodeType.fromJson(r);
        }
   
        public static List<TreeNode> expectJsonListOfTreeNode(StreamReader r, string key){
            readKey(r,key);
            expectCharacter(r,'[');
            List<TreeNode> L = new();
            while(true){
                consumeWhitespace(r);
                if( r.Peek() == '{' ){
                    L.Add( TreeNode.fromJson(r) );
                } else if( r.Peek() == ']' ){
                    r.Read();
                    return L;
                } else {
                    throw new Exception("Unexpected thing");
                }
            }
        }
    }
}
*/