using Application.Features.Common.BaseResponse;

namespace Application.Features.DataBases.Commands.Update.Responses.KO
{
    public class ExceptionUpdateDataBaseNotExisteResponse : KoObject<string>
    {
        public ExceptionUpdateDataBaseNotExisteResponse(string msg)
           : base(msg, "")
        {
        }


    }
}
