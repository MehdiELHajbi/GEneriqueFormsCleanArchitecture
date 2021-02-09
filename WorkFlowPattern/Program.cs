using System;
using WorkFlowPattern.CompositePattern;
using WorkFlowPattern.CompositePattern.StepWithComposite;
using WorkFlowPattern.CompositePattern.StepWithComposite.ImplementationFeature;
using WorkFlowPattern.CompositeSpecificationPatern;

namespace WorkFlowPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Test Spec

            var spec = new TestSpec();
            //spec.RunSpec();

            #endregion


            #region Test Composite 

            var composite = new TestComposite();
            //composite.run();

            #endregion

            #region Test Step 

            var step = new TestStep();
            //step.run();

            #endregion

            #region Test StepWithFeature

            var CreerUserStep = new TestFeatureCreateUser();
            CreerUserStep.run();

            #endregion
            Console.ReadKey();
            //https://www.codeproject.com/Articles/670115/Specification-pattern-in-Csharp
        }
    }
}
