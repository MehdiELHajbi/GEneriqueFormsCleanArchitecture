using Application.Contracts.Infrastructure;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IFLog<TRequest> _logger;

        public UnhandledExceptionBehaviour(IFLog<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                //_logger.LogError(ex, "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                _logger.Write(ex, "CleanArchitecture Request: Unhandled Exception for Request " + requestName + " --- " + request);

                throw;
            }
        }
    }

}
