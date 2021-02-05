using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class SaveDatabaseStep : IRule<Context>
    {
        private int idDataBase;
        private readonly CreateDataBesesCommand request;
        private readonly IDataBaseRepository dataBaseRepository;
        public IEnumerable<IRule<Context>> steps { get; set; }
        public string RuleDescrition { get; } = " DatabaseNotExisteStep permet permet d'enregistrer une dans la table  'DataBase' passer en parmetre existe deja dans la Bd";

        string IRule<Context>.ruleName => nameof(SaveDatabaseStep);

        public SaveDatabaseStep(CreateDataBesesCommand request, IDataBaseRepository dataBaseRepository)
        {
            this.request = request;
            this.dataBaseRepository = dataBaseRepository;
            this.idDataBase = 0;


            InitSteps();

        }

        private void InitSteps()
        {
            this.steps = new List<IRule<Context>>
                                         {
                                                new ReturnResponseStep(this.idDataBase)
                                         };
        }
        public async Task<Context> Execute(Context ctx)
        {
            // Create Object To save
            var dataBase = CreateObject();
            // save data in data Base 
            dataBase = await SaveDataInDataBase(dataBase);

            // update context with reult
            UpdateContext(ctx, dataBase);
            // Do Steps
            return await ExecuteSteps(this.steps, ctx);
        }

        public DataBase CreateObject()
        {
            // Create Object To save
            return new DataBase()
            {
                ConnetionName = this.request.ConnetionName,
                NameDataBase = this.request.NameDataBase,
                TypeDataBase = this.request.TypeDataBase
            };
        }
        public async Task<DataBase> SaveDataInDataBase(DataBase dataBase)
        {
            // Create Object To save
            return await this.dataBaseRepository.AddAsync(dataBase);
        }
        public void UpdateContext(Context ctx, DataBase dataBase)
        {
            ctx.DataBase_id = dataBase.IdDataBase;
            this.idDataBase = ctx.DataBase_id;
        }

        public async Task<Context> ExecuteSteps(IEnumerable<IRule<Context>> steps, Context ctx)
        {
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
