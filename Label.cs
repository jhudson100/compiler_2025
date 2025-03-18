public class Label{
    public string value;        //lbl###
    public string comment;      //for hyoo-man use
    
    static int ctr=0;
    public Label(string comment){
        this.value = $"lbl{ctr++}";
        this.comment = comment;
    }
    public override string ToString(){
        return this.value;
    }
}