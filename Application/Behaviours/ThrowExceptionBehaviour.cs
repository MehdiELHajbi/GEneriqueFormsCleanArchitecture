using Application.Contracts.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Behaviours
{
    public class ThrowExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IFLog<TRequest> _logger;

        public ThrowExceptionBehaviour(IFLog<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            //if (response is OneOfCreateDataBaseResponse OneOfResponse)
            //{
            //    if (OneOfResponse.ExceptionDataBaseAlreadyExistsResponse != null)
            //        throw new Exception("Exception on " + JsonConvert.SerializeObject(OneOfResponse.ExceptionDataBaseAlreadyExistsResponse));
            //}
            //if (response is ExceptionValidationResponse ExceptionValidationResponse)
            //{
            //    throw new Exception("Exception on " + JsonConvert.SerializeObject(ExceptionValidationResponse));
            //}
            return response;
        }
    }


}
