
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature.Begin.Condition.False;
using WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature.Begin.Condition.True;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature
{
    public class Context
    {
        public DataBase dataBase { get; set; }
    }
    public class UserExisteCondition : ConditionTasks
    {
        public Context context { get; set; }
        public UserExisteCondition(string name) : base(name)
        {

            // Condition que deux Step True est False sinon il y aura un Bug , les anciens True False seront ecrasé
            // Step Fonctioneel
            this.When(UserExiste())

                     .DoThisWorkFlow("Continue : si l'user n'existe pas ")
                                                            .ExecuteThisTaskWhenISTrue(CreateUserTasks("creer le user "))
                                                            .ExecuteThisTaskWhenISTrue(SuccesTasks("retourne succes "))
                     .OtherWise("Stop : si l'user existe deja")
                                                            .ExecuteThisTaskWhenISFalse(FaildTasks("Error "))

                     .Build();




            // Composite + WorkFlow + Command
        }

        #region Tasks/Step

        private CreateUserTasks CreateUserTasks(string name) { return new CreateUserTasks(name); }
        private SuccesTasks SuccesTasks(string name) { return new SuccesTasks(name); }
        private FaildTasks FaildTasks(string name) { return new FaildTasks(name); }

        #endregion

        #region Decision
        public bool UserExiste()
        {
            return true;
        }
        #endregion

        public bool DecisionAfterTasksV2()
        {
            var validator = new StepRule();
            var validRes = validator.Validate(GetDataBaseObject(2));
            if (!validRes.IsValid)
                return false;

            return true;
        }
        public bool DecisionAfterTasks()
        {
            return rules.All(rule => rule(GetData(2)));
        }


        #region Rules

        Func<object, bool>[] rules = {
                                            m => m==null
                                        };
        #endregion




        #region Tools
        private object GetData(int idDataBase)
        {
            return null;
        }
        private Context GetDataBaseObject(int idDataBase)
        {
            context.dataBase = new DataBase();
            return context;
        }

        #endregion







    }

    #region FluentValidation Rules

    public class DataBase
    {


        public int IdDataBase { get; set; }
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string ConnectionString { get; set; }
        public string TypeDataBase { get; set; }

    }
    public static class MyCustomValidators
    {

        public static IRuleBuilderOptions<T, TElement> ObjectMustBeNotNull<T, TElement>
            (this IRuleBuilder<T, TElement> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("The Obeject is Null" + nameof(TElement));
            return ruleBuilder.Must(Myobject => Myobject == null).WithMessage("The Obeject is Null" + nameof(TElement));


        }
        public static void ValidateAndThrowNotNull<T>(this IValidator<T> validator, T instance)
        {
            if (instance == null)
            {
                var validationResult = new ValidationResult(new[] { new ValidationFailure("", "Instance cannot be null") });
                new ValidationResult(new[] { new ValidationFailure(instance.ToString(), "response cannot be null", "Error") });
            }
        }
        public static IRuleBuilderOptions<T, TElement> ObjectNotNullNotNull<T, TElement>
           (this IRuleBuilder<T, TElement> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("The Obeject is Null" + nameof(TElement));
            return ruleBuilder.Must(Myobject => Myobject == null).WithMessage("The Obeject is Null" + nameof(TElement));


        }


    }

    public class StepRule : AbstractValidator<Context>
    {
        public StepRule()
        {
            RuleFor(x => x.dataBase).NotNull();
        }
    }

    public class CustumValidator<T> : AbstractValidator<T>
    {
        public CustumValidator()
        {

            //RuleFor(x => x)
        }
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            return (context.InstanceToValidate == null)
                ? new ValidationResult(new[] { new ValidationFailure("Object ", "Error Message") })
                : base.Validate(context);
        }

    }






    #endregion
}
