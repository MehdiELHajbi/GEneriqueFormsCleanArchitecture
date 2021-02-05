using Application.Features.Common.Pattern.Rule;
using Application.Features.DataBases.Commands.Create.ExceptionHandling;
using Application.Features.DataBases.Commands.Create.Responses;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class Context : IContext
    {
        public bool Continue { get; set; } = true;

        public int DataBase_id { get; set; }
        //public CreateDataBesesCommandResponse CreateDataBesesCommandResponse { get; set; }
        //public ExceptionDataBaseAlreadyExistsResponse ExceptionDataBaseAlreadyExistsResponse { get; set; }
        public OneOfCreateDataBaseResponse OneOfCreateDataBaseResponse { get; set; }

        public ResponseAbstract ResponseAbstract { get; set; }
        public object result { get; set; }

        public Context()
        {
            this.OneOfCreateDataBaseResponse = new OneOfCreateDataBaseResponse();
        }
        //public OneOfCreateDataBaseResponse GetResult(Context ctx)
        //{
        //    if (ctx.OneOfCreateDataBaseResponse.ExceptionDataBaseAlreadyExistsResponse != null)
        //        return ctx.OneOfCreateDataBaseResponse.ExceptionDataBaseAlreadyExistsResponse;
        //    if (ctx.OneOfCreateDataBaseResponse.CreateDataBesesCommandResponse != null)
        //        return ctx.OneOfCreateDataBaseResponse.CreateDataBesesCommandResponse;

        //    return "Rien";
        //    //switch (ctx)
        //    //{
        //    //    case ExceptionDataBaseAlreadyExistsResponse ExceptionDataBaseAlreadyExistsResponse:
        //    //        return ExceptionDataBaseAlreadyExistsResponse;
        //    //    case CreateDataBesesCommandResponse CreateDataBesesCommandResponse:
        //    //        return CreateDataBesesCommandResponse;
        //    //    default:
        //    //        return null;
        //    //}


        //}
        //public Dictionary<Guid, object> ExceptedReult { get; set; }
        //public object errors { get; set; }
    }
}
