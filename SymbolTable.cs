namespace lab{
    
    public static class SymbolTable{

        static public int numLocals=0;
        static int nestingLevel=0;
        static Stack< List<VarInfo> > shadowed = new();

        public static Dictionary<string, VarInfo> table = new();

        public static void enterFunctionScope(){ 
            numLocals=0;
            nestingLevel++;
            shadowed.Push(new());
        }
        public static void leaveFunctionScope(){
            nestingLevel--;
            numLocals=0;        //bogus
            removeVariablesFromTableWithNestingLevelGreaterThanThreshold(nestingLevel);
            restoreShadowedVariables();
        }

        public static void enterLocalScope(){
            nestingLevel++;    
            shadowed.Push(new());
        }
        public static void leaveLocalScope(){
            nestingLevel--;
            //...fixme...
            //destroy locals
            throw new Exception();
        }

        static void removeVariablesFromTableWithNestingLevelGreaterThanThreshold(int v){
            //delete anything from table where 
            //table thing's nestinglevel > v
        }

        static void restoreShadowedVariables(){
            foreach(VarInfo vi in shadowed.Peek()){
                string varname = vi.token.lexeme;
                table[varname] = vi;
            }
            shadowed.Pop();
        }

        public static VarInfo lookup(Token id){
            return table[id.lexeme];
            //look in table
            //find thing
            //if not found, signal error
            //else return data    
        }
        public static VarInfo lookup(string id){
            return table[id];
        }

        public static void declareGlobal(Token token, NodeType type){
            string varname = token.lexeme;
            if( table.ContainsKey(varname)){
                Utils.error(token, "Redeclaration of variable");
            }
            table[varname] = new VarInfo(token,
                nestingLevel, //always zero
                type, new GlobalLocation( new Label(token.lexeme) ));
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
        public static void declareParameter(Token token, NodeType type){ 
            //...
            throw new Exception("FINISH ME"); 
        }

        public static bool currentlyInGlobalScope(){
            throw new Exception("Finish me");
        }
    }

}
