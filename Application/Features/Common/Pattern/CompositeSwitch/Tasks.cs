using System;

namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public class Tasks : Algorithme
    {
        public Tasks(string name) : base(name) { }

        public override Context context { get; set; }

        public override void Execute()
        {

            string tab = "";
            for (int i = 0; i < niveau; i++)
            {
                tab += "----";
            }
            Console.WriteLine(tab + "  Tasks : " + name);

        }
    }
}
