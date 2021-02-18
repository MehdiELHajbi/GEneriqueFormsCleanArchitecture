using Application.Features.Common.Pattern.CompositeSwitch;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseExiste
{
    public class UpdateDataBaseTasks : Tasks
    {
        public ContextUpdateDataBase Context { get; }

        public UpdateDataBaseTasks(string name, ContextUpdateDataBase context) : base(name)
        {
            Context = context;
        }


        public override async Task<Context> ExecuteAsyn(Context ctx)
        {

            //  editing  Data
            Context.dataBases.ConnetionName = Context.req.ConnetionName;
            Context.dataBases.NameDataBase = Context.req.NameDataBase;
            Context.dataBases.TypeDataBase = Context.req.TypeDataBase;


            // Update data and Save
            await Context.dataBaseRepository.UpdateAsync(Context.dataBases);

            return Task.FromResult(Context).Result;
        }


    }
}
