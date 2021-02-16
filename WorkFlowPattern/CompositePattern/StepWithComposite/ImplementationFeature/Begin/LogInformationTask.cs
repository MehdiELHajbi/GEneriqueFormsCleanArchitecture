namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class LogInformationTask : Tasks
    {
        public LogInformationTask(string name) : base(name)
        {

        }

        public override void operation()
        {
            //Console.WriteLine(" Avant Process : " + name);
            base.operation();
            //Console.WriteLine(" Apres Process : " + name);

        }
    }
}
