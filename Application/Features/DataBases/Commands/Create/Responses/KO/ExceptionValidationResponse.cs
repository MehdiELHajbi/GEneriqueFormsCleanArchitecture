using Application.Features.Common.BaseResponse;
using System.Collections.Generic;

namespace Application.Features.DataBases.Commands.Create.Responses.KO
{
    public class ExceptionValidationResponse : KoObject<Dictionary<string, string[]>>
    {
        public ExceptionValidationResponse(Dictionary<string, string[]> errors)
            : base("One or more validation failures have occurred.", errors)
        {
            //ValidationError = new Dictionary<string, string[]>();
        }
    }
}
