namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public abstract class Algorithme
    {

        public Algorithme(string name)
        {
            this.name = name;


        }
        public string name { get; set; }
        public int niveau { get; set; }
        public abstract Context context { get; set; }


        public abstract void Execute();


    }
}
