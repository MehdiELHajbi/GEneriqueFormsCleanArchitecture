using Application.Features.Common.BaseResponse;

namespace Application.Features.DataBases.Commands.Create.Responses.OK
{
    public class CreateDataBesesCommandResponse : ReponseOK
    {
        public CreateDataBesesCommandResponse(int dataBaseID, string msg) : base(msg)
        {
            this.IdDataBase = dataBaseID;
        }
        public CreateDataBesesCommandResponse() : base()
        {

        }
        public int IdDataBase { get; set; }
    }
}
