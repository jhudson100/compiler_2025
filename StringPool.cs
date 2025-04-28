namespace lab{

public static class StringPool{
    public static Dictionary<string,Label> allStrings = new();

    static string sanitize(string s){
        string t="";
        foreach(char c in s){
            if(c>=32 && c < 127 && c != '*' )
                t += c;
            else
                t += '.';
        }
        return t;
    }
    public static Label lookup(string theString){
        if( !allStrings.ContainsKey(theString) ){
            allStrings[theString] = new Label( sanitize(theString) );
        }
        return allStrings[theString];
    }

}

}