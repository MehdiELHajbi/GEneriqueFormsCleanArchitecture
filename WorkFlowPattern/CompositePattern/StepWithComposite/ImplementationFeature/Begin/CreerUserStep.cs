namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class CreerUserStep : WorkFlow
    {
        public CreerUserStep(string name) : base(name)
        {

            add(new SwitchUserExiste("Verification de l existance de l'utlisateur"));
            //add(new UserExisteCondition("Verification de l existance de l'utlisateur"));
            add(new LogPerformanceTask("log performance"));
            add(new LogInformationTask("log information"));

        }
    }

    public class WorkFlowTest : WorkFlow
    {
        public WorkFlowTest(string name) : base(name)
        {


            add(new LogPerformanceTask("log xxxxperformance"));
            add(new LogInformationTask("log xxxxxxinformation"));

        }
    }
}
