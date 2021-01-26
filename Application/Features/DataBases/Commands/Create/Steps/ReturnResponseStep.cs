using Application.Features.Common.Pattern.Rule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class ReturnResponseStep : IRule<Context>
    {

        public IEnumerable<IRule<Context>> steps { get; set; }
        public CreateDataBesesCommandResponse CreateDataBesesCommandResponse;

        public ReturnResponseStep()
        {
            this.CreateDataBesesCommandResponse = new CreateDataBesesCommandResponse();
        }
        public Task<Context> Execute(Context ctx)
        {
            CreateDataBesesCommandResponse.IdDataBase = ctx.DataBase_id;
            CreateDataBesesCommandResponse.Message = "Create ok for id " + ctx.DataBase_id;

            ctx.ReponseObjectToApi = CreateDataBesesCommandResponse;

            return Task.FromResult(ctx);
        }
    }
}
