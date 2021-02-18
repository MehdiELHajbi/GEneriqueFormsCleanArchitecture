using Application.Features.Common.BaseResponse;
using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.Responses.KO;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseNotExiste
{
    public class FaildTasks : Tasks
    {
        public FaildTasks(string name, string msg) : base(name)
        {
            Msg = msg;
        }

        public string Msg { get; }

        public override Task<Context> ExecuteAsyn(Context ctx)
        {
            new ExceptionCustom("ExceptionDataBaseNotExisteResponse ", new ExceptionUpdateDataBaseNotExisteResponse(Msg));

            return Task.FromResult(ctx);
        }


    }
}
