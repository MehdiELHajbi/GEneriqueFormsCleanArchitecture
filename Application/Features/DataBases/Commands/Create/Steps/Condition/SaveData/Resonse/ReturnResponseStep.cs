using Application.Features.Common.Pattern.Rule;
using Application.Features.DataBases.Commands.Create.Responses.OK;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class ReturnResponseStep : ISquenceRule<Context>
    {
        public string RuleDescrition { get; } = " ReturnResponseStep de retourner la reponse";

        public IEnumerable<IRule<Context>> steps { get; set; }
        //public CreateDataBesesCommandResponse CreateDataBesesCommandResponse;
        string IRule<Context>.ruleName => nameof(ReturnResponseStep);

        //public int IdDataBase { get; }

        //public ReturnResponseStep(int idDataBase)
        //{
        //    this.IdDataBase = idDataBase;
        //    //this.CreateDataBesesCommandResponse = new CreateDataBesesCommandResponse(idDataBase, "Create ok for id " + idDataBase);
        //}
        public Task<Context> Execute(Context ctx)
        {
            ctx.ResponseAbstract = new CreateDataBesesCommandResponse(
                            ctx.DataBaseStepResult.DataBase_id,
                            "Create ok for id " + ctx.DataBaseStepResult.DataBase_id);

            return Task.FromResult(ctx);
        }
    }
}
