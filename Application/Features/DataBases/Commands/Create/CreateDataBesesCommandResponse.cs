using Application.Common.Response;

namespace Application.Features.DataBases.Commands.Create
{
    public class CreateDataBesesCommandResponse : ReponseOK
    {
        public CreateDataBesesCommandResponse() : base()
        {

        }

        public int IdDataBase { get; set; }
    }
}
