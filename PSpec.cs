namespace lab{

public class PSpec {
    public string spec;

    //WalkCallbackType = we have a function
    //that takes a TreeNode and returns nothing (void).
    public delegate void WalkCallbackType(TreeNode n);

    public WalkCallbackType collectClassNames;

    //p = "foo :: bar baz bam | boom"
    public PSpec(string p,
                 WalkCallbackType collectClassNames=null
    ){
        this.spec=p;
        this.collectClassNames = collectClassNames ?? defaultCollectClassNames;
        
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

}

} //namespace