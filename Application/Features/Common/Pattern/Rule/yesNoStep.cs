using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Common.Pattern.Rule
{
    public class yesNoStep : IRule<IContext>
    {
        public IEnumerable<IRule<IContext>> steps { get; set; }
        public IEnumerable<IRule<IContext>> stepsYes { get; set; }
        public IEnumerable<IRule<IContext>> stepsNon { get; set; }

        public string ruleName => "";

        public string RuleDescrition => "";
        public yesNoStep(IEnumerable<IRule<IContext>> stepsYes, IEnumerable<IRule<IContext>> stepsNon)
        {
            this.stepsYes = stepsYes;
            this.stepsNon = stepsNon;
        }

        public async Task<IContext> Execute(IContext ctx)
        {
            var steps = stepsYes == null ? stepsNon : stepsYes;

            foreach (var step in steps)
            {
                if (ctx.Continue) // Ne pas faire tout les Steps
                {
                    ctx = await step.Execute(ctx);
                }
                else
                    return ctx;

            }
            return ctx;


        }


    }
}
