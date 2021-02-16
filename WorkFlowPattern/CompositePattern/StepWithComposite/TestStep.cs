namespace WorkFlowPattern.CompositePattern.StepWithComposite
{


    public class TestStep
    {
        public void run()
        {



            WorkFlow racine = new WorkFlow("Ceration d'utlisateur");
            WorkFlow composite2 = new WorkFlow("si l'user n'existe pas ");

            racine.add(composite2);
            composite2.add(new Tasks("creer le user "));
            composite2.add(new Tasks("retourne succes"));
            racine.add(new Tasks("log information"));
            racine.add(new Tasks("log performance"));
            racine.add(new Tasks("log in json"));


            racine.operation();
        }
    }
}
