using Application.Features.Common.BaseResponse;
using Application.Features.Common.Pattern.Rule;
using Application.Features.DataBases.Commands.Create.Responses.KO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{

    public class StopDataBaseExisteResonse : IRule<Context>
    {
        public string RuleDescrition { get; } = " ReturnResponseStep de retourner la reponse";

        public IEnumerable<IRule<Context>> steps { get; set; }
        string IRule<Context>.ruleName => nameof(ReturnResponseStep);
        private readonly string nameDatabse;

        public StopDataBaseExisteResonse(string nameDatabse)
        {
            this.nameDatabse = nameDatabse;
        }
        public Task<Context> Execute(Context ctx)
        {
            ThrowException(ctx);
            return Task.FromResult(ctx);
        }

        public void ThrowException(Context ctx)
        {
            // utilisé cet option  pour retourner une reponse sans exception
            //ctx.ResponseAbstract = new ExceptionDataBaseAlreadyExistsResponse(this.nameDatabse);
            //ctx.Continue = false;


            new ExceptionCustom("StopDataBaseExisteResonse ", new ExceptionDataBaseAlreadyExistsResponse(this.nameDatabse));

        }
    }
}
