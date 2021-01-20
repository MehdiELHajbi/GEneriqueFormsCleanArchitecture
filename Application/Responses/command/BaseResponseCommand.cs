using System.Collections.Generic;

namespace Application.Responses.Command
{
    public class BaseResponseCommand
    {
        public BaseResponseCommand()
        {
            Success = true;
        }
        public BaseResponseCommand(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponseCommand(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
