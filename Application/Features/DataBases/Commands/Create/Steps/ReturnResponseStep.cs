using Application.Features.Common.Pattern.Rule;
using Application.Features.DataBases.Commands.Create.Responses.OK;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class ReturnResponseStep : IRule<Context>
    {
        public string RuleDescrition { get; } = " ReturnResponseStep de retourner la reponse";

        public IEnumerable<IRule<Context>> steps { get; set; }
        public CreateDataBesesCommandResponse CreateDataBesesCommandResponse;
        string IRule<Context>.ruleName => nameof(ReturnResponseStep);
        public ReturnResponseStep()
        {
            this.CreateDataBesesCommandResponse = new CreateDataBesesCommandResponse();
        }
        public ReturnResponseStep(int idDataBase)
        {
            this.CreateDataBesesCommandResponse = new CreateDataBesesCommandResponse(idDataBase, "Create ok for id " + idDataBase);
        }
        public Task<Context> Execute(Context ctx)
        {
            //CreateDataBesesCommandResponse.IdDataBase = ctx.DataBase_id;
            //CreateDataBesesCommandResponse.Message = "Create ok for id " + ctx.DataBase_id;
            ctx.ResponseAbstract = new CreateDataBesesCommandResponse(ctx.DataBase_id, "Create ok for id " + ctx.DataBase_id);
            //ctx.OneOfCreateDataBaseResponse.CreateDataBesesCommandResponse = new CreateDataBesesCommandResponse(ctx.DataBase_id, "Create ok for id " + ctx.DataBase_id);
            //new ExceptionCustom(
            //                       OneOfResponseExceptionCreate.SuceesType.CreateDataBesesCommand
            //                      , new CreateDataBesesCommandResponse(ctx.DataBase_id, "Create ok for id " + ctx.DataBase_id)
            //                      );
            return Task.FromResult(ctx);
        }
    }
}
