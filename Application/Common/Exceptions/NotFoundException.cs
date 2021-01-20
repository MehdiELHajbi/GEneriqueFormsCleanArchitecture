using Application.Common.Response;
using System;

namespace Application.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        {
            reponseKO = new ReponseKO();
            reponseKO.Message = $"{name} ({key}) is not found";

        }

        public ReponseKO reponseKO { get; }
    }
}
