using Application.Features.DataBases.Commands.Create.Responses.KO;
using Application.Features.DataBases.Commands.Create.Responses.OK;

namespace Application.Features.DataBases.Commands.Create.Responses
{
    public class OneOfCreateDataBaseResponse
    {
        public CreateDataBesesCommandResponse CreateDataBesesCommandResponse { get; set; }
        public ExceptionDataBaseAlreadyExistsResponse ExceptionDataBaseAlreadyExistsResponse { get; set; }
        public ExceptionValidationResponse ExceptionValidationResponse { get; set; }

    }
}
