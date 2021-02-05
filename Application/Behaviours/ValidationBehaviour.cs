using Application.Features.DataBases.Commands.Create.ExceptionHandling;
using Application.Features.DataBases.Commands.Create.Responses.KO;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {


            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                var ValidationError = failures
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

                if (failures.Count != 0)
                    //cancellationToken = new CancellationToken(false);
                    //ExceptionValidationExtension(ValidationError);
                    new ExceptionCustom(
                                         OneOfResponseExceptionCreate.ExceptionType.ExceptionValidation
                                        , new ExceptionValidationResponse(ValidationError)
                                       );



                //var ExceptionValidationResponse = new ExceptionValidationResponse(ValidationError);
                //return Task.FromResult<TResponse>(ExceptionValidationResponse);
            }
            return await next();
        }

        private void ExceptionValidationExtension(object ValidationError)
        {
            IDictionary<string, object> objectError = new Dictionary<string, object>();

            objectError.Add("ValidationException", ValidationError);

            //throw new new ExceptionValidationResponse(objectError);
        }
    }

}
