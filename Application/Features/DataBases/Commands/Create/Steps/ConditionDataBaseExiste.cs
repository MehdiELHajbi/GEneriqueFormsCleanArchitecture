using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class ConditionDataBaseExiste : IConditionRule<Context>
    {
        private IDataBaseRepository dataBaseRepository;
        private CreateDataBesesCommand request;
        public IEnumerable<IRule<Context>> stepsIfTrue { get; set; }
        public IEnumerable<IRule<Context>> stepsIfFalse { get; set; }

        public string ruleName => "condition Rule true or false";

        public string RuleDescrition => "execute soit les Steps true ou flase";


        public ConditionDataBaseExiste(CreateDataBesesCommand request, IDataBaseRepository dataBaseRepository)
        {
            this.request = request;
            this.dataBaseRepository = dataBaseRepository;

            InitSteps();

        }
        public async Task<Context> Execute(Context ctx)
        {

            if (DataBaseExiste().Result)
                return await ExecuteSteps(stepsIfTrue, ctx);
            else
                return await ExecuteSteps(stepsIfFalse, ctx);

        }

        private void InitSteps()
        {
            this.stepsIfTrue = new List<IRule<Context>>
                                         {
                                                 new StopDataBaseExisteResonse(this.request.NameDataBase)
                                         };

            this.stepsIfFalse = new List<IRule<Context>>
                                         {
                                                new SaveDatabaseStep(this.request,this.dataBaseRepository)
                                         };
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
        public async Task<DataBase> getDataBaseByID()
        {
            return await this.dataBaseRepository.GetFirstOrDefault(s => s.NameDataBase == this.request.NameDataBase);
        }

        public async Task<bool> DataBaseExiste()
        {
            DataBase existe = await getDataBaseByID();

            if (existe == null) return false;

            return true;
        }
    }
}
