using System;
using System.Collections.Generic;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{

    public class Step : Algorithme
    {

        public Step(string name) : base(name)
        {
            Algorithmes = new List<Algorithme>();
        }

        public List<Algorithme> Algorithmes { get; set; }




        public override void operation()
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
                tab += "----";

            Console.WriteLine(tab + " Step: " + name);


            foreach (Algorithme a in Algorithmes)
            {
                a.operation();
            }
        }

        public void add(Algorithme c)
        {
            c.niveau = this.niveau + 1;
            Algorithmes.Add(c);
        }
        public void remove(Algorithme c)
        {
            Algorithmes.Remove(c);
        }

        public List<Algorithme> getChilds()
        {
            return Algorithmes;
        }

    }

}
