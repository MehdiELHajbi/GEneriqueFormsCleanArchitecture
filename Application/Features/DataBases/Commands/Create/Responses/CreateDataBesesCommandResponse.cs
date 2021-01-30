using Application.Features.Common.BaseResponse;

namespace Application.Features.DataBases.Commands.Create.Responses
{
    public class CreateDataBesesCommandResponse : ReponseOK
    {
        public CreateDataBesesCommandResponse() : base()
        {

        }

        public int IdDataBase { get; set; }
    }
}
