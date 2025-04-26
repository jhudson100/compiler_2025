namespace lab{

public class CustomCodeTreeNode: TreeNode{

    public delegate void CodeGen();
    public CodeGen codeGen;

    public CustomCodeTreeNode( CodeGen f ): base("$custom$", -1 ){
        this.codeGen=f;
    }
    public override void generateCode()
    {
        codeGen();
    }
}

} //namespace