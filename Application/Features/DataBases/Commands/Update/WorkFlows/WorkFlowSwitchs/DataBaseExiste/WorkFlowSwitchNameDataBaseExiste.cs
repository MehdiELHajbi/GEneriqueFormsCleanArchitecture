using Application.Features.Common.Pattern.CompositeSwitch;
using Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseNotExiste;

namespace Application.Features.DataBases.Commands.Update.WorkFlows.WorkFlowSwitchs.DataBaseExiste
{

    public class WorkFlowSwitchNameDataBaseExiste : WorkFlowSwitch
    {
        public ContextUpdateDataBase Context { get; }

        //public ContextUpdateDataBase Ctx { get; set; }

        public enum Decisions
        {
            Name_DataBase_Existe,
            Name_DataBase_Not_Existe
        }

        public WorkFlowSwitchNameDataBaseExiste(string name, ContextUpdateDataBase context) : base(name)
        {
            Context = context;

            this.Switch(NameDataBaseExiste(context))
                                 .When(Decisions.Name_DataBase_Not_Existe)
                                         .Do(UpdateDataBaseTasks("Update Data Base  ", context))
                                         .Do(SuccesTasks("Return succes "))
                                 .When(Decisions.Name_DataBase_Existe)
                                         .Do(FaildTasks(" Return Error ", "Name database existe deja"))
                                 .Build();
        }



        #region Decision
        public Decisions NameDataBaseExiste(ContextUpdateDataBase context)
        {

            if (context.dataBases.NameDataBase == context.req.NameDataBase)

                return Decisions.Name_DataBase_Existe;


            return Decisions.Name_DataBase_Not_Existe;

        }


        #endregion


        #region Tasks/WorkFlow

        private UpdateDataBaseTasks UpdateDataBaseTasks(string name, ContextUpdateDataBase context) { return new UpdateDataBaseTasks(name, context); }
        private SuccesTasks SuccesTasks(string name) { return new SuccesTasks(name); }
        private FaildTasks FaildTasks(string name, string msg) { return new FaildTasks(name, msg); }

        #endregion
    }

}
