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

        //public List<dynamic> OneOf = new List<dynamic>() { new ValidationException(), new CreateDataBesesCommandResponse(), new AlreadyExists("", null), new NotFoundException("ddddf", "dd") };
        public string RuleDescrition { get; } = " CreateDatabaseObjectStep permet de creer une ligne dans la table 'DataBase' ";

        public string RuleExcptOutPut { get; } = "";

        string IRule<Context>.ruleName => nameof(CreateDatabaseObjectStep);

        private Context ctx;

        public CreateDatabaseObjectStep(Context ctx, CreateDataBesesCommand request, IDataBaseRepository dataBaseRepository)
        {
            this.request = request;
            this._dataBaseRepository = dataBaseRepository;
            this.ctx = ctx;
            this.steps = new List<IRule<Context>>
                                         {
                                                new IfDatabaseExisteStep(request.NameDataBase,dataBaseRepository),
                                                new ElseDatabaseNotExisteStep(request,dataBaseRepository)
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
