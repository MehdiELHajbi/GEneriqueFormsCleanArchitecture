using Application.Features.Common.Pattern.Rule;

namespace Application.Features.DataBases.Commands.Create.Step
{
    public class Context : IContext
    {
        public bool Continue { get; set; } = true;

        public int DataBase_id { get; set; }
        //public CreateDataBesesCommandResponse result { get; set; }

        //public Dictionary<Guid, object> ExceptedReult { get; set; }
        //public object errors { get; set; }
    }
}
