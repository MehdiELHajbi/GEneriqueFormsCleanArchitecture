namespace WorkFlowPattern.CompositePattern.Step
{
    public abstract class Algorithme
    {

        public Algorithme(string name)
        {
            this.name = name;
        }
        public string name;
        public int niveau;


        public abstract void operation();


    }
}
