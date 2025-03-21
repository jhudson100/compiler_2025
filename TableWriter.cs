using System.Net.Mail;

namespace lab{

public static class TableWriter{

    public static void create(){
        //create a file called ParseTable.cs which has the parse table
        using( var w = new StreamWriter("ParseTable.cs") ){
            w.WriteLine("namespace lab{");
            w.WriteLine("public static class ParseTable{");
            w.WriteLine("    public static List<Dictionary<string,ParseAction> > table = new() {");

            for(int i=0;i<DFA.allStates.Count;++i){
                w.WriteLine("        // DFA STATE "+i); //index in allStates == state's "unique" number
                DFAState q = DFA.allStates[i];
                foreach(LRItem I in q.label.items){
                    w.WriteLine($"        // {I}");
                }
                w.WriteLine("        new Dictionary<string,ParseAction>(){");
                //shift rules
                foreach( string sym in q.transitions.Keys){
                    w.Write("                ");
                    w.Write("{");
                    w.Write($"\"{sym}\" , ");
                    w.Write($"new ParseAction(PAction.SHIFT, {q.transitions[sym].unique}, null, -1)");
                    w.WriteLine("},");
                }
                //reduce rules
                foreach( LRItem I in q.label.items){
                    if( I.dposAtEnd() ){

                        foreach(LRItem II in q.label.items){
                            if( Object.ReferenceEquals(I,II) || !II.dposAtEnd() )
                                continue;
                            var conflicts = I.lookahead.Intersect(II.lookahead).ToList();
                            if( conflicts.Count > 0 ){
                                Console.WriteLine("Error: Reduce-reduce conflict on {"+
                                    String.Join(", ",conflicts)+"} in state "+q.unique);
                                foreach(LRItem III in q.label.items){
                                    Console.WriteLine("    "+III);
                                }
                                Environment.Exit(1);
                            }
                        }

                        foreach( string lookahead in I.lookahead){
                            if( q.transitions.ContainsKey(lookahead) ){
                                Console.WriteLine("Warning: Shift-reduce conflict on "+lookahead+" in state "+q.unique);
                                foreach(LRItem II in q.label.items){
                                    Console.WriteLine("    "+II);
                                }
                                continue;   //prefer shift to reduce
                            }

                            w.Write($"                ");
                            w.Write("{");
                            w.Write($"\"{lookahead}\"");
                            w.Write(",");
                            w.Write($"new ParseAction(PAction.REDUCE, {I.production.rhs.Length}, \"{I.production.lhs}\", {I.production.unique})");
                            w.WriteLine("},");
                        }
                    }
                }
                w.WriteLine("        },");
            }

            w.WriteLine("    }; //close the table initializer");
            w.WriteLine("} //close the ParseTable class");
            w.WriteLine("} //close the namespace lab thing");
        }
    }



} //class TableWriter

} //namespace lab