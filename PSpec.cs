namespace lab{

public class PSpec {
    public string spec;

    //WalkCallbackType = we have a function
    //that takes a TreeNode and returns nothing (void).
    public delegate void WalkCallbackType(TreeNode n);

    public WalkCallbackType collectClassNames;
    public WalkCallbackType setNodeTypes;

    //p = "foo :: bar baz bam | boom"
    public PSpec(string p,
                 WalkCallbackType collectClassNames=null,
                 WalkCallbackType setNodeTypes=null
    ){
        this.spec=p;
        this.collectClassNames = collectClassNames ?? defaultCollectClassNames;
        this.setNodeTypes = setNodeTypes ?? defaultSetNodeTypes;
        // if( collectClassNames != null )
        //     this.collectClassNames = collectClassNames;
        // else
        //     this.collectClassNames = defaultCollectClassNames;

    }

    void defaultCollectClassNames(TreeNode n){
        foreach(TreeNode c in n.children){
            c.collectClassNames();
        }
    }

    void defaultSetNodeTypes(TreeNode n){
        foreach(TreeNode c in n.children){
            c.setNodeTypes();
        }
        if( n.children.Count == 1 && n.children[0].nodeType != null && n.nodeType == null )
            n.nodeType = n.children[0].nodeType;
    }

}

} //namespace