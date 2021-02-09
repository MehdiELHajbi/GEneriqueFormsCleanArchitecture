using System.Collections.Generic;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{
    public class ConditionProcess : Step
    {
        public Step True;
        public Step False;

        public List<Process> ListProcessTrue;
        public List<Process> ListProcessFalse;
        public ConditionProcess(string name) : base(name)
        {

            ListProcessTrue = new List<Process>();
            ListProcessFalse = new List<Process>();

        }
        public override void operation()
        {
            base.operation();
        }

    }




    public static class ConditionProcessExtension
    {

        public static ConditionProcess Build(this ConditionProcess ConditionProcess)
        {
            ConditionProcess.add(ConditionProcess.True);
            ConditionProcess.add(ConditionProcess.False);

            foreach (Algorithme a in ConditionProcess.ListProcessTrue)
            {
                ConditionProcess.True.add(a);
            }
            foreach (Algorithme a in ConditionProcess.ListProcessFalse)
            {
                ConditionProcess.False.add(a);
            }


            return ConditionProcess;
        }
        public static ConditionProcess addCondition(this ConditionProcess ConditionProcess, string NameCondition)
        {

            return ConditionProcess;
        }
        public static ConditionProcess AddStepTrue<T>(this ConditionProcess ConditionProcess, string nameStep)
        {
            ConditionProcess.True = new Step(nameStep);

            return ConditionProcess;
        }

        public static ConditionProcess AddProcessTrue(this ConditionProcess ConditionProcess, string ProcessName)
        {
            ConditionProcess.ListProcessTrue.Add(new Process(ProcessName));
            return ConditionProcess;
        }


        public static ConditionProcess AddStepFalse(this ConditionProcess ConditionProcess, string nameStep)
        {
            ConditionProcess.False = new Step(nameStep);


            return ConditionProcess;
        }
        public static ConditionProcess AddProcessFalse(this ConditionProcess ConditionProcess, string ProcessName)
        {
            ConditionProcess.ListProcessFalse.Add(new Process(ProcessName));

            return ConditionProcess;

        }
    }
}
