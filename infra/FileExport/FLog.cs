using Application.Contracts.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace infra.FileExport
{
    public class FLog<T> : IFLog<T>
    {
        private readonly ILogger<T> _logger;

        public FLog(ILogger<T> logger)
        {
            _logger = logger;
        }
        public void WriteError(Exception ex, string msg)
        {
            _logger.LogInformation("------------------------");
            _logger.LogError(ex.StackTrace, msg);
            _logger.LogInformation("------------------------");
            _logger.LogError(ex.Demystify(), msg);


            //_logger.LogError(ex, "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", "xxxxxxx", "xxxxxxxxxx");
            //_logger.LogError("CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}");
        }

        public void WriteInformation(string msg)
        {
            _logger.LogInformation(msg);
        }
    }
}
