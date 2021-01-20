using MediatR;

namespace Application.Features.DataBases.Commands.Update
{
    public class UpdateDataBesesCommand : IRequest<UpdateDataBesesCommandResponse>
    {
        public int idDataBase { get; set; }
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string TypeDataBase { get; set; }
    }
}
