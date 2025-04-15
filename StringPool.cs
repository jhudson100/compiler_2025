namespace lab{

public static class StringPool{
    public static Dictionary<string,Label> allStrings = new();

    public static void addString(string theString){
        if( !allStrings.ContainsKey(theString) ){
            allStrings[theString] = new Label( theString );
        }
    }


}

}