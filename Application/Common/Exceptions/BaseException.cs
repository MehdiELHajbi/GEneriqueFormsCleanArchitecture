using Application.Common.Response;
using System;

namespace Application.Common.Exceptions
{
    public class BaseException : ApplicationException
    {
        public BaseException(string message) : base(message)
        {
            reponseKO = new ReponseKO();
            reponseKO.Message = message;
        }

        public ReponseKO reponseKO { get; }
    }
}
