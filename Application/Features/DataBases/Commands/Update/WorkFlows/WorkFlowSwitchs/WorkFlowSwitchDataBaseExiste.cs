using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseExiste;
using Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseNotExiste;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs
{

    public class WorkFlowSwitchDataBaseExiste : WorkFlowSwitch
    {
        public ContextUpdateDataBase Context { get; }

        //public ContextUpdateDataBase Ctx { get; set; }

        public enum Decisions
        {
            Id_DataBase_Existe,
            Id_DataBase_Not_Existe
        }

        public WorkFlowSwitchDataBaseExiste(string name, ContextUpdateDataBase context) : base(name)
        {
            Context = context;

            this.Switch(DataBaseExiste(context))
                                 .When(Decisions.Id_DataBase_Existe)
                                         .Do(WorkFlowSwitchNameDataBaseExiste("Data Base Name Existe ? ", context))
                                 .When(Decisions.Id_DataBase_Not_Existe)
                                         .Do(FaildTasks(" Return Error ", "Id dataBase n'existe pas"))
                                 .Build();
        }



        #region Decision
        public Decisions DataBaseExiste(ContextUpdateDataBase context)
        {


            var entity = Task.FromResult(context.dataBaseRepository.GetByIdAsync(context.req.idDataBase)).Result.Result;
            if (entity == null)
            {
                return Decisions.Id_DataBase_Not_Existe;
            }
            Context.dataBases = entity;

            return Decisions.Id_DataBase_Existe;

        }
        #endregion


        #region Tasks/WorkFlow

        private WorkFlowSwitchNameDataBaseExiste WorkFlowSwitchNameDataBaseExiste(string name, ContextUpdateDataBase context) { return new WorkFlowSwitchNameDataBaseExiste(name, context); }
        private FaildTasks FaildTasks(string name, string msg) { return new FaildTasks(name, msg); }

        #endregion
    }
}
