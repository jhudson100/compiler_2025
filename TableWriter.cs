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
                w.WriteLine("        new Dictionary<string,ParseAction>(){");
                //shift rules
                DFAState q = DFA.allStates[i];
                foreach( string sym in q.transitions.Keys){
                    w.Write("                ");
                    w.Write("{");
                    w.Write($"\"{sym}\" , ");
                    w.Write($"new ParseAction(PAction.SHIFT, {q.transitions[sym].unique}, null)");
                    w.WriteLine("},");
                }
                //reduce rules
                foreach( LRItem I in q.label.items){
                    if( I.dposAtEnd() ){
                        w.WriteLine($"            // {I}");
                        foreach( string lookahead in I.lookahead){
                            w.Write($"            ");
                            w.Write("{");
                            w.Write($"\"{lookahead}\"");
                            w.Write(",");
                            w.Write($"new ParseAction(PAction.REDUCE, {I.production.rhs.Length}, \"{I.production.lhs}\")");
                            w.WriteLine("},");
                        }
                    }
                }
                w.WriteLine("        }");
            }

            w.WriteLine("    }; //close the table initializer");
            w.WriteLine("} //close the ParseTable class");
            w.WriteLine("} //close the namespace lab thing");
        }
        /*
                new(){      //one of these for each DFA state
                    { "ID" , new(...) },    //one of these for each shift
                    { "ID" , new(...) },    //one of these for each reduction
                }
        */

    }



} //class TableWriter

} //namespace lab