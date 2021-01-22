﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviours.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Log.Debug("Entering LoggingBehavior with request {Name}", typeof(TRequest).Name);
            var msg1 = "Entering LoggingBehavior with request " + typeof(TRequest).Name;



            var response = await next();

            //Log.Debug("Leaving LoggingBehavior with request {Name}", typeof(TRequest).Name);

            return response;
        }
    }


}
