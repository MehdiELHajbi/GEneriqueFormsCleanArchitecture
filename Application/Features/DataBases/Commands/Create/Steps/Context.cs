using Application.Features.Common.Pattern.Rule;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class Context : IContext
    {
        public bool Continue { get; set; } = true;

        public int DataBase_id { get; set; }
        public CreateDataBesesCommandResponse ReponseObjectToApi { get; set; }


    }
}
