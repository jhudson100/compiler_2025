namespace lab{
    
public static class SymbolTable{

    public static Dictionary<string,VarInfo> table = new();
    static Stack<List<VarInfo>> shadowed = new();
    static Stack< HashSet<String> > locals = new();
    static int numLocals = 0;
    static int numParameters=0;

    public static void enterFunctionScope(){ 
        numParameters = 0;
        numLocals = 0;
        shadowed.Push( new() );
        locals.Push( new() );
    }
    public static void leaveFunctionScope(){
        foreach(string s in locals.Peek() )
            table.Remove(s);
        locals.Pop();
        foreach(var vi in shadowed.Pop() )
            table[vi.token.lexeme] = vi;
    }

    public static void enterLocalScope(){
        shadowed.Push( new() );
        locals.Push( new() );
    }
    public static void leaveLocalScope(){
        foreach( string name in locals.Peek() )
            table.Remove(name);
        locals.Pop();
        foreach( var vi in shadowed.Pop() )
            table[vi.token.lexeme] = vi;
    }

    public static VarInfo lookup(Token id){
        string name = id.lexeme;
        if( !table.ContainsKey(name) )
            Utils.error(id,$"Use of undeclared variable {name}");
        return table[name];
    }

    public static VarInfo lookup(string name){
        if( !table.ContainsKey(name) )
            Utils.error($"Use of undeclared variable {name}");
        return table[name];
    }

    public static void declareGlobal(Token token, NodeType type){ 
        if( table.ContainsKey(token.lexeme) )
            Utils.error(token,$"Redeclaration of global variable {token.lexeme}");
        table[token.lexeme] = new VarInfo(token,0,type,new GlobalLocation(new Label(token.lexeme)));
    }
    public static void declareLocal(Token token, NodeType type){
        string name = token.lexeme;
        if( table.ContainsKey(name)){
            var info = table[name];
            if( info.nesting == locals.Count )
                Utils.error(token,$"Redeclaration of local variable {name}");
            shadowed.Peek().Add(table[name]);
        }
        table[name] = new VarInfo(token,locals.Count,type,new LocalLocation(numLocals,name));
        locals.Peek().Add(name);
        numLocals++;
    }

    public static void declareParameter(Token token, NodeType type){ 
        string name = token.lexeme;
        if( table.ContainsKey(name)){
            var info = table[name];
            if( info.nesting == locals.Count )
                Utils.error(token,$"Redeclaration of parameter {name}");
            shadowed.Peek().Add(table[name]);
        }
        //locals.Count is the nesting level
        table[name] = new VarInfo(token,locals.Count,type,new ParameterLocation(numParameters));
        locals.Peek().Add(name);
        numParameters++;
    }

    public static bool currentlyInGlobalScope(){ 
        return locals.Count == 0;
    }
}

} //namespace lab