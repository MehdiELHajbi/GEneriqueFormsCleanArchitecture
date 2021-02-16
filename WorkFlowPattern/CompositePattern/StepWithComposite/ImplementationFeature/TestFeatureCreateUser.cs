namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class TestFeatureCreateUser
    {
        public void run()
        {
            WorkFlow racine = new CreerUserStep("Ceration d'utlisateur");
            //Step composite2 = new Step("si l'user n'existe pas ");

            //racine.add(composite2);
            //composite2.add(new Process("creer le user "));
            //composite2.add(new Process("retourne succes"));
            //racine.add(new Process("log information"));
            //racine.add(new Process("log performance"));
            //racine.add(new Process("log in json"));

            //var json = JsonConvert.SerializeObject(racine);
            racine.operation();


        }
    }
}
