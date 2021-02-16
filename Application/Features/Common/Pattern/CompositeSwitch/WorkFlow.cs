using System;
using System.Collections.Generic;

namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public class WorkFlow : Algorithme
    {

        public override Context context { get; set; }

        public WorkFlow(string name) : base(name)
        {
            Algorithmes = new List<Algorithme>();
        }

        public List<Algorithme> Algorithmes { get; set; }




        public override void Execute()
        {

            string tab = "";
            for (int i = 0; i < niveau; i++)
                tab += "----";
            Console.WriteLine(tab + " WorkFlow: " + name);


            foreach (Algorithme a in Algorithmes)
            {
                a.Execute();
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
