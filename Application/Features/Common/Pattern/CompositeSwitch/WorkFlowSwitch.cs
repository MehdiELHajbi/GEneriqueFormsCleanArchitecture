using System.Collections.Generic;

namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public class WorkFlowSwitch : WorkFlow
    {
        public override Context context { get; set; }
        public string keyRule;
        private List<Algorithme> ListRules;

        public string Decision;
        public Dictionary<string, List<Algorithme>> Rules;


        public List<Algorithme> GetListeRules() { return ListRules; }
        public void SetListeRules() { ListRules = new List<Algorithme>(); }
        public void AddToListeRules(Algorithme tasks) { ListRules.Add(tasks); }

        public WorkFlowSwitch(string name) : base(name)
        {
            Rules = new Dictionary<string, List<Algorithme>>();
            SetListeRules();
        }
    }


    public static class SwitchExtension
    {

        public static WorkFlowSwitch Build(this WorkFlowSwitch Switch)
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

        public static WorkFlowSwitch Switch(this WorkFlowSwitch Switch, object decision)
        {
            var dc = decision.ToString();
            Switch.Decision = dc;
            return Switch;
        }
        public static WorkFlowSwitch When(this WorkFlowSwitch Switch, object keyRule)
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
        public static WorkFlowSwitch Do(this WorkFlowSwitch Switch, Algorithme task)
        {
            Switch.AddToListeRules(task);

            return Switch;
        }









    }


}
