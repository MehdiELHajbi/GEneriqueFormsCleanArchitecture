using System;

namespace WorkFlowPattern.CompositePattern
{
    public class Element : Composant
    {
        public Element(string name) : base(name) { }

        public override void operation()
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
            {
                tab += "----";
            }

            Console.WriteLine(tab + "Element : " + name);
        }
    }
}
