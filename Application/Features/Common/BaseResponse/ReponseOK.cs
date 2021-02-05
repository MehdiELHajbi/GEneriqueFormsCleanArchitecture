using Application.Features.DataBases.Commands.Create.ExceptionHandling;

namespace Application.Features.Common.BaseResponse
{
    public class ReponseOK : ResponseAbstract
    {
        public ReponseOK()
        {
            Success = true;
        }
        public ReponseOK(string message = null)
        {
            Success = true;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        //public IDictionary<string, string[]> data { get; }
    }
}
