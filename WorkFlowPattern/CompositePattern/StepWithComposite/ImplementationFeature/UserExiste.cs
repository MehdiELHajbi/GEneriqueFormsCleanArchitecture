namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class UserExiste : Step
    {
        Step Way1;
        Step Way2;
        public UserExiste(string name) : base(name)
        {
            Way1 = new Step("si l'user n'existe pas ");
            Way2 = new Step("si l'user existe deja ");

            this.add(Way1);
            this.add(Way2);


            Way1.add(new Process("creer le user "));
            Way1.add(new Process("retourne succes"));

            Way2.add(new Process("Error "));
            Way2.add(new Process("retourne Faild"));



        }

        public override void operation()
        {
            //this.remove(Way2);
            base.operation();
            //this.add(Way2);
            base.operation();

        }
    }
}
