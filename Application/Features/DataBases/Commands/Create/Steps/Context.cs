using Application.Features.Common.BaseResponse;
using Application.Features.Common.Pattern.Rule;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class Context : IContext
    {
        public Context()
        {
            this.DataBaseStepResult = new DataBaseStepResult();
        }
        public bool Continue { get; set; } = true;


        public DataBaseStepResult DataBaseStepResult { get; set; }


        public ResponseAbstract ResponseAbstract { get; set; }

    }

    public class DataBaseStepResult
    {
        public int DataBase_id { get; set; }
    }
}
