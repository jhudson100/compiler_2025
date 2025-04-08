namespace lab{
    
    public static class SymbolTable{

        static Stack<List<VarInfo>> shadowed = new();
        static Stack< HashSet<String> > locals = new();
        static int numParameters=0;
        static public int numLocals=0;
        static int nestingLevel=0;

        public static Dictionary<string, VarInfo> table = new();


        static void removeVariablesFromTableWithNestingLevelGreaterThanThreshold(int v){
            //delete anything from table where 
            //table thing's nestinglevel > v
            List<string> toRemove = new();
            foreach(var name in table.Keys){
                if( table[name].nestingLevel > v )
                    toRemove.Add(name);
            }
            foreach( var name in toRemove ){
                table.Remove(name);
            }
        }

        static void restoreShadowedVariables(){
            foreach(VarInfo vi in shadowed.Peek()){
                string varname = vi.token.lexeme;
                table[varname] = vi;
            }
            shadowed.Pop();
        }
 
        public static void declareGlobal(Token token, NodeType type,
                    Label lbl=null
        ){
            if( lbl == null )
                lbl = new Label(token.lexeme);
            
            string varname = token.lexeme;
            if( table.ContainsKey(varname)){
                Utils.error(token, "Redeclaration of variable");
            }
            table[varname] = new VarInfo(token,
                nestingLevel, //always zero
                type, new GlobalLocation( lbl ));
        }

        public static void declareLocal(Token token, NodeType type){
            string varname = token.lexeme;
            if( table.ContainsKey(varname)){
                VarInfo vi = table[varname];
                if( vi.nestingLevel == nestingLevel ){
                    Utils.error(token, "Redeclaration of variable");
                } else if( vi.nestingLevel > nestingLevel ){
                    throw new Exception("ICE");
                } else {
                    //vi.nestingLevel must be < nestingLevel
                    shadowed.Peek().Add( table[varname] );
                }
            }
            table[varname] = new VarInfo(token, 
                    nestingLevel, 
                    type, 
                    new LocalLocation(numLocals, token.lexeme)
            );
            numLocals++;
        }
        
        public static void enterFunctionScope(){ 
            numParameters = 0;
            numLocals = 0;
            shadowed.Push( new() );
            locals.Push( new() );
            nestingLevel++;
        }


        public static void leaveFunctionScope(){
            nestingLevel--;
            numLocals=0;        //bogus
            removeVariablesFromTableWithNestingLevelGreaterThanThreshold(nestingLevel);
            restoreShadowedVariables();
        }

        public static void enterLocalScope(){
            nestingLevel++;    
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
                Utils.error(null,$"Use of undeclared variable {name}");
            return table[name];
        }

        public static void declareParameter(Token token, NodeType type){ 
            string name = token.lexeme;
            if( table.ContainsKey(name)){
                var info = table[name];
                if( info.nestingLevel == locals.Count )
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

        public static void populateBuiltins(){
            SymbolTable.declareGlobal(
                new Token("ID", "putc", -1),
                new FunctionNodeType(NodeType.Bool,
                    new List<NodeType>(){NodeType.Int}
                ),
                new Label("putc","builtin function putc")
            );
        }
    }

} //namespace lab
