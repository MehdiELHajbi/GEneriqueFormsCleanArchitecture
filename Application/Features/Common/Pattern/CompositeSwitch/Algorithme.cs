using System.Threading.Tasks;

namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public abstract class Algorithme
    {

        public Algorithme(string name)
        {
            this.name = name;


        }
        public string name { get; set; }
        public int niveau { get; set; }


        public abstract Task<Context> ExecuteAsyn(Context ctx);
        //public abstract void Execute();


    }
}
