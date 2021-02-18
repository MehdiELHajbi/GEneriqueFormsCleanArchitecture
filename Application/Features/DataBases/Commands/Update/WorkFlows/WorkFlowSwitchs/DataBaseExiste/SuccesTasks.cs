using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.Responses.OK;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseExiste
{
    public class SuccesTasks : Tasks
    {
        public SuccesTasks(string name) : base(name)
        {

        }
        public override async Task<Context> ExecuteAsyn(Context ctx)
        {
            ctx.Result = new UpdateDataBesesCommandResponse("update ok");


            return await base.ExecuteAsyn(ctx);
        }
    }
}
