using System.Collections.Generic;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{


    public class ConditionTasks : WorkFlow
    {
        public WorkFlow True;
        public WorkFlow False;
        public bool Decision;
        public List<Tasks> ListTasksTrue;
        public List<Tasks> ListTasksFalse;


        public ConditionTasks(string name) : base(name)
        {

            ListTasksTrue = new List<Tasks>();
            ListTasksFalse = new List<Tasks>();

        }
        public override void operation()
        {
            this.DoDecision(Decision);
            base.operation();
        }

    }




    public static class ConditionTasksExtension
    {

        public static ConditionTasks Build(this ConditionTasks ConditionTasks)
        {
            ConditionTasks.add(ConditionTasks.True);
            ConditionTasks.add(ConditionTasks.False);

            foreach (Algorithme a in ConditionTasks.ListTasksTrue)
            {
                ConditionTasks.True.add(a);
            }
            foreach (Algorithme a in ConditionTasks.ListTasksFalse)
            {
                ConditionTasks.False.add(a);
            }


            return ConditionTasks;
        }

        public static ConditionTasks When(this ConditionTasks ConditionTasks, bool decision)
        {
            ConditionTasks.Decision = decision;
            return ConditionTasks;
        }
        public static ConditionTasks addCondition(this ConditionTasks ConditionTasks, string NameCondition)
        {

            return ConditionTasks;
        }
        public static ConditionTasks DoDecision(this ConditionTasks ConditionTasks, bool Decision)
        {
            if (Decision)
                ConditionTasks.DoTrue();
            else
                ConditionTasks.DoFalse();


            return ConditionTasks;
        }
        public static ConditionTasks DoThisWorkFlow(this ConditionTasks ConditionTasks, string nameStep)
        {
            ConditionTasks.True = new WorkFlow(nameStep);

            return ConditionTasks;
        }

        public static ConditionTasks ExecuteThisTaskWhenISTrue(this ConditionTasks ConditionTasks, Tasks Tasks)
        {
            ConditionTasks.ListTasksTrue.Add(Tasks);
            return ConditionTasks;
        }

        public static ConditionTasks RemoveStepTrue(this ConditionTasks ConditionTasks)
        {
            ConditionTasks.remove(ConditionTasks.True);



            return ConditionTasks;
        }


        public static ConditionTasks DoTrue(this ConditionTasks ConditionTasks)
        {
            ConditionTasks.RemoveStepFalse();
            return ConditionTasks;
        }

        public static ConditionTasks OtherWise(this ConditionTasks ConditionTasks, string nameStep)
        {
            ConditionTasks.False = new WorkFlow(nameStep);


            return ConditionTasks;
        }

        public static ConditionTasks RemoveStepFalse(this ConditionTasks ConditionTasks)
        {
            ConditionTasks.remove(ConditionTasks.False);

            return ConditionTasks;
        }


        public static ConditionTasks ExecuteThisTaskWhenISFalse(this ConditionTasks ConditionTasks, Tasks Tasks)
        {
            ConditionTasks.ListTasksFalse.Add(Tasks);

            return ConditionTasks;

        }

        public static ConditionTasks DoFalse(this ConditionTasks ConditionTasks)
        {
            ConditionTasks.RemoveStepTrue();
            return ConditionTasks;
        }
    }
}
