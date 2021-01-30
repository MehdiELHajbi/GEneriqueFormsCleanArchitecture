using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class ElseDatabaseNotExisteStep : IRule<Context>
    {
        public string RuleDescrition { get; } = " DatabaseNotExisteStep permet de lancer le next steps";

        private readonly CreateDataBesesCommand request;
        private readonly IDataBaseRepository dataBaseRepository;
        public IEnumerable<IRule<Context>> steps { get; set; }


        string IRule<Context>.ruleName => nameof(ElseDatabaseNotExisteStep);
        public ElseDatabaseNotExisteStep(CreateDataBesesCommand request, IDataBaseRepository dataBaseRepository)
        {
            this.request = request;
            this.dataBaseRepository = dataBaseRepository;

            this.steps = new List<IRule<Context>>
                                         {
                                                new SaveDatabaseStep(request,dataBaseRepository)
                                         };

        }

        public async Task<Context> Execute(Context ctx)
        {
            foreach (var step in this.steps)
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
