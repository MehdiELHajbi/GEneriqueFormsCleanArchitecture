using WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature.Begin.Condition.False;
using WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature.Begin.Condition.True;

namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class UserExisteCondition : ConditionProcess
    {

        public UserExisteCondition(string name) : base(name)
        {

            this

                     .AddStepTrue("Continue : si l'user n'existe pas ")
                                                            .AddProcessTrue(new CreateUserProcess("creer le user "))
                                                            .AddProcessTrue(new SuccesProcess("retourne succes "))
                     .AddStepFalse("Stop : si l'user existe deja")
                                                            .AddProcessFalse(new FaildProcess("Error "))

                     .Build();



        }

        public override void operation()
        {
            //this.RemoveStepFalse();
            //this.RemoveStepTrue();
            base.operation();
            //base.operation();

        }
    }
}
