using System;
using System.Collections.Generic;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{

    public class WorkFlow : Algorithme
    {


        public WorkFlow(string name) : base(name)
        {
            Algorithmes = new List<Algorithme>();
        }

        public List<Algorithme> Algorithmes { get; set; }




        public override void operation()
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
                tab += "----";

            if (this is ConditionTasks)
                Console.WriteLine(tab + " Condition WorkFlow: " + name);

            Console.WriteLine(tab + " WorkFlow: " + name);


            foreach (Algorithme a in Algorithmes)
            {
                a.operation();
            }


        }

        //public void addList(List<Algorithme> algorithmes)
        //{
        //    foreach (Algorithme a in algorithmes)
        //    {
        //        add(a);
        //    }
        //}

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
