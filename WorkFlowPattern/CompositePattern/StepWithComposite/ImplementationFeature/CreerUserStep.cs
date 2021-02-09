namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class CreerUserStep : Step
    {
        public CreerUserStep(string name) : base(name)
        {
            add(new UserExiste("Verification de l existance de l'utlisateur"));
            add(new LogPerformanceProcess("log performance"));
            add(new LogInformationProcess("log information"));

        }
    }
}
