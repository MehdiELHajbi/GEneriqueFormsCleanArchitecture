using System;
using System.Threading.Tasks;

namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public abstract class Tasks : Algorithme
    {
        public Tasks(string name) : base(name) { }





        public override Task<Context> ExecuteAsyn(Context ctx)
        {
            string tab = "";
            for (int i = 0; i < niveau; i++)
            {
                tab += "----";
            }
            Console.WriteLine(tab + "  Tasks : " + name);

            return Task.FromResult(ctx);
        }
    }
}
