using System.Collections.Generic;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{


    public class Switch : WorkFlow
    {


        public string keyRule;
        private List<Algorithme> ListRules;

        public string Decision;
        public Dictionary<string, List<Algorithme>> Rules;


        public List<Algorithme> GetListeRules() { return ListRules; }
        public void SetListeRules() { ListRules = new List<Algorithme>(); }
        public void AddToListeRules(Algorithme tasks) { ListRules.Add(tasks); }

        public Switch(string name) : base(name)
        {
            Rules = new Dictionary<string, List<Algorithme>>();
            SetListeRules();
        }

    }




    public static class SwitchExtension
    {

        public static Switch Build(this Switch Switch)
        {
            // Ajouter les Dernieres régles
            Switch.Rules.Add(Switch.keyRule, Switch.GetListeRules());

            // Cle existe
            if (Switch.Rules.ContainsKey(Switch.Decision))
                foreach (Algorithme a in Switch.Rules[Switch.Decision])
                {
                    Switch.Algorithmes.Add(a);
                }


            return Switch;
        }

        public static Switch Switch(this Switch Switch, object decision)
        {
            var dc = decision.ToString();
            Switch.Decision = dc;
            return Switch;
        }
        public static Switch When(this Switch Switch, object keyRule)
        {
            var kR = keyRule.ToString();
            if (!Switch.Rules.ContainsKey(kR) && Switch.GetListeRules().Count > 0)
            {
                Switch.Rules.Add(Switch.keyRule, Switch.GetListeRules());
                Switch.SetListeRules();

            }


            Switch.keyRule = kR;
            return Switch;
        }
        public static Switch Do(this Switch Switch, Algorithme task)
        {
            Switch.AddToListeRules(task);

            return Switch;
        }









    }
}
