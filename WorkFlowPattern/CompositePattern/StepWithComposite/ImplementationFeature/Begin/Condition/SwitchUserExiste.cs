using WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature.Begin.Condition.False;
using WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature.Begin.Condition.True;

namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{

    public class SwitchUserExiste : SwitchRules
    {
        public enum Decisions
        {
            User_Existe,
            User_Not_Existe,
            defaults
        }

        public SwitchUserExiste(string name) : base(name)
        {

            this.Switch(UserExiste())
                                    .When(Decisions.User_Existe)
                                            .Do(CreateUserTasks("creer le user "))
                                            .Do(SuccesTasks("retourne succes "))
                                    .When(Decisions.User_Not_Existe)
                                        .Do(FaildTasks("Error "))
                                        .Do(WorkFlowTest("Reverification"))
                .Build();
        }

        #region Tasks/Step

        private CreateUserTasks CreateUserTasks(string name) { return new CreateUserTasks(name); }
        private SuccesTasks SuccesTasks(string name) { return new SuccesTasks(name); }
        private FaildTasks FaildTasks(string name) { return new FaildTasks(name); }
        private WorkFlowTest WorkFlowTest(string name) { return new WorkFlowTest(name); }

        #endregion

        #region Decision
        public Decisions UserExiste()
        {
            return Decisions.User_Not_Existe;

        }
        #endregion


















    }


}
