using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseExiste;
using Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseNotExiste;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs
{

    public class WorkFlowSwitchDataBaseExiste : WorkFlowSwitch
    {
        public ContextUpdateDataBase Ctx { get; }

        public enum Decisions
        {
            DataBase_Existe,
            DataBase_Not_Existe
        }

        public WorkFlowSwitchDataBaseExiste(string name, ContextUpdateDataBase ctx) : base(name)
        {

            this.Switch(DataBaseExiste())
                                    .When(Decisions.DataBase_Existe)
                                            .Do(UpdateDataBaseTasks("Update Data Base  "))
                                            .Do(SuccesTasks("Return succes "))
                                    .When(Decisions.DataBase_Not_Existe)
                                            .Do(FaildTasks(" Return Error "))
                .Build();
            Ctx = ctx;
        }

        #region Decision
        public Decisions DataBaseExiste()
        {


            var entity = Task.FromResult(this.context.dataBaseRepository.GetByIdAsync(Ctx.req.idDataBase)).Result;

            if (entity == null)
            {
                return Decisions.DataBase_Not_Existe;
            }
            return Decisions.DataBase_Existe;

        }
        #endregion


        #region Tasks/WorkFlow

        private UpdateDataBaseTasks UpdateDataBaseTasks(string name) { return new UpdateDataBaseTasks(name); }
        private SuccesTasks SuccesTasks(string name) { return new SuccesTasks(name); }
        private FaildTasks FaildTasks(string name) { return new FaildTasks(name); }

        #endregion
    }
}
