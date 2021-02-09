using System;

namespace WorkFlowPattern.CompositePattern
{
    public abstract class Composant
    {

        public Composant(string name)
        {
            this.name = name;
        }
        protected string name;
        public int niveau;
        public DateTime started;
        public DateTime ended;
        public string ReturnType;
        public object Exception;


        public abstract void operation();
        //public abstract Composant findComposant(string name);
        ////public abstract void UpdateNode(string node);
        //public abstract void UpdateNodeOnExitForMethode(string node, object parameterExity);

        //public abstract void UpdateNodeOnExitExceptionForMethode(string node, object parameterExity);

        //public abstract void AddNode(string node, Methode child);
    }

}
