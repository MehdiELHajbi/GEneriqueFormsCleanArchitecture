using System.Threading;

namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature.Begin.Condition.True
{
    public class SuccesTasks : Tasks
    {
        public SuccesTasks(string name) : base(name)
        {

        }

        public override void operation()
        {
            Thread.Sleep(2000);
            base.operation();

        }
    }
}
