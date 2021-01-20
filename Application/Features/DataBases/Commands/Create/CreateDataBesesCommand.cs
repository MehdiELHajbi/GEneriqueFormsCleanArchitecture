using MediatR;

namespace Application.Features.DataBases.Commands.Create
{
    public class CreateDataBesesCommand : IRequest<CreateDataBesesCommandResponse>
    {
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string TypeDataBase { get; set; }
    }
}
