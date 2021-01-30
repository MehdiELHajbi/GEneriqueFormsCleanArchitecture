namespace Application.Features.Common.BaseResponse
{
    public class ReponseKO
    {
        public ReponseKO()
        {
            Success = false;
            DetailsErrors = new object();
        }
        public ReponseKO(string message = null)
        {
            Success = false;
            Message = message;
            DetailsErrors = new object();
        }


        public ReponseKO(string message, object errors)
        {
            Success = false;
            Message = message;
            DetailsErrors = errors;
        }

        public bool Success { get; }
        public string Message { get; set; }
        public string LinkRedirection { get; set; }
        public string LinkToResolveException { get; set; }
        public object DetailsErrors { get; }

    }


}
