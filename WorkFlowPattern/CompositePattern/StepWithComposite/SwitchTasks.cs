using System.Collections.Generic;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{


    public class SwitchRules : WorkFlow
    {


        public string Decision;
        public string keyRule;
        private List<Algorithme> ListRules;
        public Dictionary<string, List<Algorithme>> Rules;


        public List<Algorithme> GetListeRules() { return ListRules; }
        public void SetListeRules() { ListRules = new List<Algorithme>(); }
        public void AddToListeRules(Algorithme tasks) { ListRules.Add(tasks); }

        public SwitchRules(string name) : base(name)
        {
            Rules = new Dictionary<string, List<Algorithme>>();
            SetListeRules();
            //True = new WorkFlow(name);
        }

    }




    public static class SwitchRulesExtension
    {

        public static SwitchRules Build(this SwitchRules SwitchRules)
        {
            // Ajouter les Dernieres régles
            SwitchRules.Rules.Add(SwitchRules.keyRule, SwitchRules.GetListeRules());

            // Cle existe
            if (SwitchRules.Rules.ContainsKey(SwitchRules.Decision))
                foreach (Algorithme a in SwitchRules.Rules[SwitchRules.Decision])
                {
                    SwitchRules.Algorithmes.Add(a);
                }


            return SwitchRules;
        }

        public static SwitchRules Switch(this SwitchRules SwitchRules, object decision)
        {
            var dc = decision.ToString();
            SwitchRules.Decision = dc;
            return SwitchRules;
        }
        public static SwitchRules When(this SwitchRules SwitchRules, object keyRule)
        {
            var kR = keyRule.ToString();
            if (!SwitchRules.Rules.ContainsKey(kR) && SwitchRules.GetListeRules().Count > 0)
            {
                SwitchRules.Rules.Add(SwitchRules.keyRule, SwitchRules.GetListeRules());
                SwitchRules.SetListeRules();

            }


            SwitchRules.keyRule = kR;
            return SwitchRules;
        }
        public static SwitchRules Do(this SwitchRules SwitchRules, Algorithme task)
        {
            SwitchRules.AddToListeRules(task);

            return SwitchRules;
        }









    }
}
