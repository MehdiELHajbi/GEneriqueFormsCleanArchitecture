using Application.Contracts.Infrastructure;
using Application.Features.Common.BaseResponse;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Application.Behaviours
{
    public class LogExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IFLog<TRequest> _logger;

        public LogExceptionBehaviour(IFLog<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception exception)
            {

                //var requestName = typeof(TRequest).Name;

                //_logger.LogError(ex, "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

                //_logger.WriteError(ex, "CleanArchitecture - RequestName:  " + requestName + " -Request :  " + request);
                //_logger.WriteError(ex, ConvertException(ex));
                //_logger.WriteError(ex, JsonConvert.SerializeObject(((ResponseException)ex).ResponseApiObject));


                switch (exception)
                {
                    case ResponseException ResponseException:

                        _logger.WriteError(exception, JsonConvert.SerializeObject(ResponseException.ResponseApiObject));

                        break;
                    case Exception ex:
                        _logger.WriteError(ex, JsonConvert.SerializeObject(ex));

                        break;
                }
                throw;
            }
        }
        //private string ConvertException(Exception exception)
        //{
        //    switch (exception)
        //    {
        //        case ValidationException validationException:
        //            return JsonConvert.SerializeObject(validationException.reponseKO);
        //        case NotFoundException notFoundException:
        //            return JsonConvert.SerializeObject(notFoundException.reponseKO);

        //        case Exception ex:
        //            break;


        //    }

        //    return "";
        //}
    }


}
