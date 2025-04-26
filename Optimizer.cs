namespace lab
{

    public static class Optimizer
    {
        static int PEEPHOLE_SIZE = 20;


        delegate bool OpCheck(Opcode op);
        delegate bool OpApply(int initialIndex, int finalIndex);

        static void move(int idx,
                        IntRegister A, int B,
                        IntRegister C, IntRegister D)
        {
            //mov A->C, B->D. No need to worry about conflicts.
            Asm.ops[idx] = new OpMov(A, C);
            Asm.ops.Insert(idx + 1, new OpMov(B, D));
        }
        static void move(int idx, IntRegister A, IntRegister B,
                                IntRegister C, IntRegister D)
        {
            //mov A->C, B->D.
            if (A == C && B == D)
            {
                Asm.ops[idx] = new OpComment("optimized out");
            }
            else if (A == B || C == D)
            {
                throw new Exception();
            }
            else if (A == D && B == C)
            {
                Asm.ops[idx] = new OpXchg(A, B);
            }
            else if (B == C)
            {
                //D != A because we checked that above
                Asm.ops[idx] = new OpMov(B, D);
                Asm.ops.Insert(idx + 1, new OpMov(A, C));
            }
            else
            {
                Asm.ops[idx] = new OpMov(A, C);
                Asm.ops.Insert(idx + 1, new OpMov(B, D));
            }
        }

        static int applyOptimization(
                OpCheck initial,
                OpCheck intermediate,
                OpCheck final,
                OpApply apply)
        {

            int total = 0;              //how many changes have we made?

            for (int i = 0; i < Asm.ops.Count; ++i)
            {
                if (initial(Asm.ops[i]) == false)
                    continue;
                int j;
                bool ok = false;
                for (j = i + 1; j < Asm.ops.Count && j - i < PEEPHOLE_SIZE; ++j)
                {
                    if (final(Asm.ops[j]))
                    {
                        ok = true;
                        break;
                    }
                    if (!intermediate(Asm.ops[j]))
                        break;
                }
                if (ok)
                {
                    bool applied = apply(i, j);
                    if (applied)
                        total++;
                }
            }
            return total;

        }

        public static int applyAll()
        {
            int o1 = opt1();
            Console.WriteLine("opt1: " + o1);
            int o2 = opt2();
            Console.WriteLine("opt2: " + o1);
            return o1 + o2;
        }


        public static int opt1()
        {
            return applyOptimization(
                initial: (op) =>
                {
                    var push = op as OpPush;
                    return push != null && push.pushesStorageClass();
                },
                intermediate: (op) =>
                {
                    return !op.touchesStack() && !op.transfersControl();
                },
                final: (op) =>
                {
                    var pop = op as OpPop;
                    return pop != null && pop.discardsStorageClass();
                },
                apply: (i, j) =>
                {
                    var push = Asm.ops[i] as OpPush;
                    var pop = Asm.ops[j] as OpPop;
                    push.doNotPushStorageClass();
                    pop.doNotPopStorageClass();
                    return true;
                }
            );
        } //opt1


        public static int opt2()
        {
            OpPush push = null;
            OpPop pop = null;

            return applyOptimization(
                initial: (op) =>
                {
                    push = op as OpPush;
                    return push != null && push.pushesStorageClass();
                },
                intermediate: (op) =>
                {
                    return !op.touchesStack() &&
                            !op.transfersControl() &&
                            !op.writesToRegister(push.valueRegister()) &&
                            !op.writesToRegister(push.storageClassRegister());
                },
                final: (op) =>
                {
                    pop = op as OpPop;
                    return pop != null && pop.popsStorageClass();
                },
                apply: (i, j) =>
                {
                    Asm.ops[i] = new OpComment("optimized out: push");
                    if (push.storageClassRegister() == null)
                    {
                        move(j,
                            push.valueRegister(), push.storageClassValue(),
                            pop.valueRegister(), pop.storageClassRegister()
                        );
                    }
                    else
                    {
                        move(j,
                            push.valueRegister(), push.storageClassRegister(),
                            pop.valueRegister(), pop.storageClassRegister()
                        );
                    }
                    return true;
                }
            );
        }


        static TreeNode followUnitProductions( TreeNode n ){
            while(true){
                if( n.children.Count == 0 )
                    return n;   //leaf
                else if( n.children.Count == 1 )
                    n=n.children[0];
                else
                    return n;
            }
        }


        static void optSubtractConstantFromVariable(TreeNode root){
            Utils.walk( root, (stmt) => {
                if( stmt.sym != "stmt" )
                    return true;

                var assign = stmt.children[0];
                if( assign.sym != "assign" )
                    return true;

                var lhs = followUnitProductions(assign.children[0]);
                if( lhs.sym != "ID" )
                    return true;

                var sumexp = followUnitProductions(assign.children[2]);
                if( sumexp.sym != "sumexp" )
                    return true;
                if( sumexp.children[1].token.lexeme != "-" )
                    return true;
                var term1 = followUnitProductions( sumexp.children[0] );
                var term2 = followUnitProductions( sumexp.children[2] );
                if( term1.sym != "ID" || term2.sym != "NUM" )
                    return true;

                long num = Int64.Parse(term2.token.lexeme);
                if( num < -0x80000000 || num > 0x7fffffff )
                    return true;
                if( term1.varInfo.location != lhs.varInfo.location)
                    return true; 

                TreeNode X = new CustomCodeTreeNode(
                    () => {
                        Asm.add(new OpComment("Optimized add constant to variable"));
                        lhs.parent.pushAddressToStack();
                        Asm.add( new OpPop(Register.rax,null));
                        Asm.add( new OpSubIndirect( Register.rax, 8, (int)num, term1.token.lexeme));
                    }
                );
                stmt.replaceChild(assign,X);
                return false;    
            });

        }

    } //end class Optimizer


} //namespace