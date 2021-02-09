
namespace Application.Features.Common.BaseResponse
{
    public class OkObject : ResponseAbstract
    {
        public OkObject()
        {
            Success = true;
        }
        public OkObject(string message = null)
        {
            Success = true;
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; set; }
        //public IDictionary<string, string[]> data { get; }
    }
}
