using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public abstract class WorkFlow : Algorithme
    {


        public WorkFlow(string name) : base(name)
        {
            Algorithmes = new List<Algorithme>();
        }

        public List<Algorithme> Algorithmes { get; set; }




        public override async Task<Context> ExecuteAsyn(Context ctx)
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
                tab += "----";
            Console.WriteLine(tab + " WorkFlow: " + name);


            foreach (Algorithme step in Algorithmes)
            {

                ctx = await step.ExecuteAsyn(ctx);



            }

            return ctx;


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
