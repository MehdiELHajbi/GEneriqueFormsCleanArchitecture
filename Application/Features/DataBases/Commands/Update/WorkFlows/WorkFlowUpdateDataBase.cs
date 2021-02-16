using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs;

namespace Application.Features.DataBases.Commands.Update.WorkFlows
{

    public class WorkFlowUpdateDataBase : WorkFlow
    {
        public WorkFlowUpdateDataBase(string name) : base(name)
        {

            add(new WorkFlowSwitchDataBaseExiste("Verification de l existance de l'utlisateur"));

        }
    }

}
