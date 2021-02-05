using Application.Features.DataBases.Commands.Create.ExceptionHandling;

namespace Application.Features.Common.BaseResponse
{
    public class ReponseKO<T> : ResponseAbstract
    {
        //public ReponseKO()
        //{
        //    Success = false;
        //}
        //public ReponseKO(string message = null)
        //{
        //    Success = false;
        //    Message = message;
        //}


        public ReponseKO(string message, T errors)
        {
            Success = false;
            Message = message;
            DetailsErrors = errors;
        }


        public bool Success { get; }
        public string Message { get; set; }
        public string LinkRedirection { get; set; }
        public string LinkToResolveException { get; set; }
        public T DetailsErrors { get; }

    }


}
