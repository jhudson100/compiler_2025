namespace lab{

public static class Parser{

    public static TreeNode parse(Tokenizer tokenizer){
        
        var stk = new Stack<int>();
        var tstk = new Stack<TreeNode>();

        stk.Push(0);

        Token tok=tokenizer.next();
        while(true){
            int currentState = stk.Peek();
            Dictionary<string,ParseAction> row = ParseTable.table[currentState];
            if( !row.ContainsKey(tok.sym) ){
                Console.WriteLine($"At line number {tok.line}:");
                Console.WriteLine($"Unexpected token {tok.sym} ({tok.lexeme})");
                Console.WriteLine("I expected to see one of:");
                foreach(string sym in row.Keys){
                    Console.Write($"{sym} ");
                }
                Console.WriteLine();
                Environment.Exit(1);
            };
            ParseAction A = row[tok.sym];
            if(A.action == PAction.SHIFT) {
                stk.Push(A.num);
                tstk.Push( new TreeNode( tok.sym, tok, -1) );
                tok = tokenizer.next();
            } else {
                //REDUCE!
                if( A.sym == "S'"){
                    return tstk.Pop();
                }

                var n = new TreeNode( A.sym, null, A.productionNumber );
                for(int i=0;i<A.num;++i){
                    stk.Pop();
                    var c = tstk.Pop();
                    n.prependChild(c);
                }

                currentState = stk.Peek();
                stk.Push( ParseTable.table[currentState][A.sym].num );
                tstk.Push(n);
            }
        }

    }
}
}