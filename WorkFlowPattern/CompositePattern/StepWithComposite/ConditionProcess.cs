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
        public static ConditionProcess AddStepTrue(this ConditionProcess ConditionProcess, string nameStep)
        {
            ConditionProcess.True = new Step(nameStep);

            return ConditionProcess;
        }

        public static ConditionProcess AddProcessTrue(this ConditionProcess ConditionProcess, Process process)
        {
            ConditionProcess.ListProcessTrue.Add(process);
            return ConditionProcess;
        }

        public static ConditionProcess RemoveStepTrue(this ConditionProcess ConditionProcess)
        {
            ConditionProcess.remove(ConditionProcess.True);



            return ConditionProcess;
        }


        public static ConditionProcess AddStepFalse(this ConditionProcess ConditionProcess, string nameStep)
        {
            ConditionProcess.False = new Step(nameStep);


            return ConditionProcess;
        }

        public static ConditionProcess RemoveStepFalse(this ConditionProcess ConditionProcess)
        {
            ConditionProcess.remove(ConditionProcess.False);

            return ConditionProcess;
        }


        public static ConditionProcess AddProcessFalse(this ConditionProcess ConditionProcess, Process process)
        {
            ConditionProcess.ListProcessFalse.Add(process);

            return ConditionProcess;

        }
    }
}
