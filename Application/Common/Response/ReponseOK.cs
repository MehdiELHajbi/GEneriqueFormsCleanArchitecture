namespace Application.Common.Response
{
    public class ReponseOK
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
