using System;
using System.Collections.Generic;

namespace WorkFlowPattern.CompositePattern
{
    public class Composite : Composant
    {

        public Composite(string name) : base(name)
        {
            composants = new List<Composant>();
        }

        //public string Controller { get; set; }
        //public string ActionName { get; set; }
        //public object ParameterEntry { get; set; }

        //public string Request { get; set; }
        //public string Reponse { get; set; }
        public List<Composant> composants { get; set; }


        public void AddComposant(Composant composant)
        {
            composant.niveau = this.niveau + 1;
            composants.Add(composant);

        }

        public override void operation()
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
                tab += "----";

            Console.WriteLine(tab + " Composite: " + name);


            foreach (Composant c in composants)
            {
                c.operation();
            }
        }

        public void add(Composant c)
        {
            c.niveau = this.niveau + 1;
            composants.Add(c);
        }
        public void remove(Composant c)
        {
            composants.Remove(c);
        }

        public List<Composant> getChilds()
        {
            return composants;
        }
        //Update on Exit
        //public override void UpdateNode( string node)
        //{
        //    foreach (Composant c in composants)
        //    {
        //        if (c.name == node)
        //        {
        //            c.ended = DateTime.Now;
        //        }
        //        else
        //            c.UpdateNode(node);
        //    }
        //}



        //public override Composant findComposant(string name)
        //{
        //    foreach (Composant c in composants)
        //    {
        //        if (c.name != name)
        //            return c.findComposant(name);
        //        else
        //        {
        //            return (Composant)c;
        //        }
        //    }
        //    return null;
        //}

        //public Composant find(string name)
        //{

        //    return composants.Find(x => x.name == name);

        //}




        //public override void UpdateNodeOnExitForMethode(string node, object parameterExity)
        //{
        //    foreach (Composant c in composants)
        //    {
        //        c.UpdateNodeOnExitForMethode(node, parameterExity);
        //    }
        //}
    }
}
