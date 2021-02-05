using Application.Features.DataBases.Commands.Create.ExceptionHandling;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    //https://stackoverflow.com/questions/12519561/throw-httpresponseexception-or-return-request-createerrorresponse


    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;


            switch (exception)
            {
                //case ValidationException validationException:
                //    httpStatusCode = HttpStatusCode.BadRequest;
                //    result = JsonConvert.SerializeObject(validationException.reponseKO);

                //    break;
                //case BadRequestException badRequestException:
                //    httpStatusCode = HttpStatusCode.BadRequest;
                //    result = JsonConvert.SerializeObject(badRequestException.reponseKO);

                //    break;
                //case NotFoundException notFoundException:
                //    httpStatusCode = HttpStatusCode.NotFound;
                //    result = JsonConvert.SerializeObject(notFoundException.reponseKO);
                //    break;
                //case AlreadyExists alreadyExists:
                //    httpStatusCode = HttpStatusCode.BadRequest;
                //    result = JsonConvert.SerializeObject(alreadyExists.reponseKO);
                //    break;
                //case BaseException baseException:
                //    httpStatusCode = HttpStatusCode.BadRequest;
                //    result = JsonConvert.SerializeObject(baseException.reponseKO);
                //    break;
                case OneOfResponseExceptionCreate OneOfResponseExceptionCreate:

                    httpStatusCode = HttpStatusCode.BadRequest;

                    if (OneOfResponseExceptionCreate.succes)
                        httpStatusCode = HttpStatusCode.OK;


                    result = JsonConvert.SerializeObject(OneOfResponseExceptionCreate.ResponseApiObject);
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            if (result == string.Empty)
            {
                var msg = "";
                if (exception.InnerException != null)
                    msg = exception.InnerException.Message;

                msg = JsonConvert.SerializeObject(new { error = exception.Message }) + " InnerException " + msg;

                result = msg;
            }

            return context.Response.WriteAsync(result);
        }
    }

}
