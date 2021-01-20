using Application.Common.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            ValidationError = new Dictionary<string, string[]>();
            //reponseKO = new ReponseKO();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            ValidationError = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

            reponseKO.ListeError.Add(ValidationError);
            reponseKO.Message = "One or more validation failures have occurred.";
        }

        public IDictionary<string, string[]> ValidationError { get; }
        public ReponseKO reponseKO { get; }

    }
}
