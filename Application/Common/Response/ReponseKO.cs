using System.Collections.Generic;

namespace Application.Common.Response
{
    public class ReponseKO
    {
        public ReponseKO()
        {
            Success = false;
            ListeError = new List<IDictionary<string, string[]>>();
        }
        public ReponseKO(string message = null)
        {
            Success = false;
            Message = message;
            ListeError = new List<IDictionary<string, string[]>>();
        }

        public ReponseKO(string message, bool success)
        {
            Success = success;
            Message = message;
            ListeError = new List<IDictionary<string, string[]>>();
        }

        public bool Success { get; }
        public string Message { get; set; }
        public List<IDictionary<string, string[]>> ListeError { get; set; }
    }
}
