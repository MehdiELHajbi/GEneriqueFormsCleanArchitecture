namespace WorkFlowPattern.CompositePattern.Step
{
    public abstract class Algorithme
    {

        public Algorithme(string name)
        {
            this.name = name;

        }
        public string name { get; set; }
        public int niveau { get; set; }


        public abstract void operation();


    }
}
