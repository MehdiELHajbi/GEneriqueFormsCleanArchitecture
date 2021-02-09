using System;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{
    public class Process : Algorithme
    {
        public Process(string name) : base(name) { }

        public override void operation()
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
            {
                tab += "----";
            }

            Console.WriteLine(tab + "  Process : " + name);
        }
    }
}
