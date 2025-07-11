namespace lab{

public class PSpec {
    public string spec;

    //WalkCallbackType = we have a function
    //that takes a TreeNode and returns nothing (void).
    public delegate void WalkCallbackType(TreeNode n);

    public WalkCallbackType collectClassNames;
    public WalkCallbackType collectFunctionNames;
    public WalkCallbackType setNodeTypes;
    public WalkCallbackType generateCode;
    public WalkCallbackType pushAddressToStack;
    public WalkCallbackType returnCheck;

    public PSpec(string p,
                 WalkCallbackType collectClassNames=null,
                 WalkCallbackType collectFunctionNames=null,
                 WalkCallbackType setNodeTypes=null,
                 WalkCallbackType generateCode=null,
                 WalkCallbackType pushAddressToStack=null,
                 WalkCallbackType returnCheck=null
    ){
        this.spec=p;
        this.collectClassNames = collectClassNames ?? defaultCollectClassNames;
        this.collectFunctionNames = collectFunctionNames ?? defaultCollectFunctionNames;
        this.setNodeTypes = setNodeTypes ?? defaultSetNodeTypes;
        this.generateCode = generateCode ?? defaultGenerateCode;
        this.pushAddressToStack = pushAddressToStack ?? defaultPushAddressToStack;
        this.returnCheck = returnCheck ?? defaultReturnCheck;
    }

    void defaultCollectClassNames(TreeNode n){
        foreach(TreeNode c in n.children){
            c.collectClassNames();
        }
    }

    void defaultCollectFunctionNames(TreeNode n){
        foreach(TreeNode c in n.children){
            c.collectFunctionNames();
        }
    }

    public static void defaultSetNodeTypes(TreeNode n){
        foreach(TreeNode c in n.children){
            c.setNodeTypes();
        }
        if( n.children.Count == 1 &&
            n.children[0].nodeType != null &&
            n.nodeType == null){
                n.nodeType = n.children[0].nodeType;
        }
    }

    void defaultGenerateCode(TreeNode n){
        foreach(TreeNode c in n.children){
            c.generateCode();
        }
    }

    void defaultReturnCheck(TreeNode n){
        foreach( var c in n.children )
            c.returnCheck();
    }

    public void defaultPushAddressToStack(TreeNode n){
         if( n.children.Count == 1 )
             n.children[0].pushAddressToStack();
         else
             Utils.error(n.firstToken(), "Expected lvalue");
     }



}

} //namespace
