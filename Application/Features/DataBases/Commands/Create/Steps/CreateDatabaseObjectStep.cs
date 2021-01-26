using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class CreateDatabaseObjectStep : IRule<Context>
    {
        private readonly CreateDataBesesCommand request;
        private readonly IDataBaseRepository _dataBaseRepository;
        public IEnumerable<IRule<Context>> steps { get; set; }
        public string ruleName { get; set; }

        public string RuleDescrition { get; } = "";

        public string RuleExcptOutPut { get; } = "";

        public Context ctx;

        public CreateDatabaseObjectStep(CreateDataBesesCommand request, IDataBaseRepository dataBaseRepository)
        {
            this.request = request;
            this._dataBaseRepository = dataBaseRepository;
            this.ctx = new Context();
            this.steps = new List<IRule<Context>>
                                         {
                                                new DatabaseExisteStep(request.NameDataBase,dataBaseRepository),
                                                new SaveDatabaseStep(request,dataBaseRepository),
                                                new ReturnResponseStep()
                                         };
        }



        public async Task<Context> Execute(Context ctx)
        {

            foreach (var step in this.steps)
            {
                if (this.ctx.Continue) // Ne pas faire tout les Steps
                {
                    this.ctx = await step.Execute(this.ctx);
                }
                else
                    return this.ctx;

            }
            return this.ctx;
        }
    }
}
