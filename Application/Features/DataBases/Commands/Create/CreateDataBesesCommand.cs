using Application.Features.DataBases.Commands.Create.ExceptionHandling;
using MediatR;

namespace Application.Features.DataBases.Commands.Create
{
    public class CreateDataBesesCommand : IRequest<ResponseAbstract>
    {
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string TypeDataBase { get; set; }
    }




}
