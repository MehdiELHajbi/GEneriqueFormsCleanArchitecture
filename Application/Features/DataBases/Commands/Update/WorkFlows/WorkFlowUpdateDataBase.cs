using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs;

namespace Application.Features.DataBases.Commands.Update.WorkFlows
{

    public class WorkFlowUpdateDataBase : WorkFlow
    {
        public WorkFlowUpdateDataBase(string name, ContextUpdateDataBase context) : base(name)
        {

            add(new WorkFlowSwitchDataBaseExiste("Verification de l existance de l'utlisateur", context));

        }
        //public ContextUpdateDataBase Ctx { get; }

    }

}
