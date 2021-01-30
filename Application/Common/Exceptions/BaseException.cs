
using Application.Features.Common.BaseResponse;
using System;

namespace Application.Common.Exceptions
{
    public class BaseException : ApplicationException
    {
        public BaseException(string message) : base(message)
        {
            reponseKO = new ReponseKO(message);
        }
        public BaseException(string message, object errors) : base(message)
        {
            reponseKO = new ReponseKO(message, errors);
        }

        public ReponseKO reponseKO { get; }

    }
}
