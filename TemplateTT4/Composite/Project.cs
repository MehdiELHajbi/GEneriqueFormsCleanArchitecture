namespace TemplateTT4.Composite
{

    public abstract class Project
    {

        public Project(string name)
        {
            this.name = name;
        }
        protected string name;
        public int niveau;


        public abstract void operation(string path);
    }
}
