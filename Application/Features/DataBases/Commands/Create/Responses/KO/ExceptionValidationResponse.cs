using Application.Common.Exceptions;

namespace Application.Features.DataBases.Commands.Create.Responses.KO
{
    public class ExceptionValidationResponse : BaseException
    {
        public ExceptionValidationResponse(object errors)
            : base("One or more validation failures have occurred.", errors)
        {
            //ValidationError = new Dictionary<string, string[]>();
        }
    }
}
