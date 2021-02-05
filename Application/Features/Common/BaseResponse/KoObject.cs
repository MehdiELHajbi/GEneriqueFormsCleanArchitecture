namespace Application.Features.Common.BaseResponse
{
    //public class ReponseKO<T> : ResponseAbstract
    public class KoObject<T>
    {


        public KoObject(string messages, T errors)
        {
            Success = false;
            Messages = messages;
            DetailsErrors = errors;

        }

        public bool Success { get; }
        public string Messages { get; set; }
        public string LinkRedirection { get; set; }
        public string LinkToResolveException { get; set; }
        public T DetailsErrors { get; }
    }


}
