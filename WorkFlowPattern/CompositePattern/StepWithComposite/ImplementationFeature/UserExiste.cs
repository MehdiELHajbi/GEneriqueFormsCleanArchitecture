namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class UserExiste : ConditionProcess
    {

        public UserExiste(string name) : base(name)
        {

            this.addCondition("Condition Process")

                     .AddStepTrue("si l'user n'existe pas ")
                                                            .AddProcessTrue("creer le user ")
                                                            .AddProcessTrue("retourne succes ")
                     .AddStepFalse("si l'user existe deja")
                                                            .AddProcessFalse("Error ")
                                                            .AddProcessFalse("retourne Faild ")
                     .Build();


            //this.add(True);
            //this.add(False);


            //True.add(new Process("creer le user "));
            //True.add(new Process("retourne succes"));

            //False.add(new Process("Error "));
            //False.add(new Process("retourne Faild"));



        }

        public override void operation()
        {
            this.remove(True);
            base.operation();
            //base.operation();

        }
    }
}
