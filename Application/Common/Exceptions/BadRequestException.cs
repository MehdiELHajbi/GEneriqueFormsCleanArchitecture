using Application.Common.Response;
using System;

namespace Application.Common.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
            reponseKO = new ReponseKO();
            reponseKO.Message = message;
        }

        public ReponseKO reponseKO { get; }
    }
}
