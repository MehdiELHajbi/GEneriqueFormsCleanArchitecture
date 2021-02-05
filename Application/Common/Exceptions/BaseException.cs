
using Application.Features.Common.BaseResponse;
using System;

namespace Application.Common.Exceptions
{
    public class BaseException<T> : ApplicationException
    {
        //public BaseException(string message) : base(message)
        //{
        //    reponseKO = new ReponseKO(message);
        //}
        public BaseException(string message, T errors) : base(message)
        {
            reponseKO = new ReponseKO<T>(message, errors);
        }

        public ReponseKO<T> reponseKO { get; }

    }
}
