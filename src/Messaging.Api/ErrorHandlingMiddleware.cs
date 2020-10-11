using Microsoft.AspNetCore.Http;
using System;

using System.Net;
using System.Threading.Tasks;


using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Messaging.Api
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory factory)
        {
            this.next = next;
            this.logger = factory.CreateLogger("Logger");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                this.LogException(ex);
            }
        }

        private void LogException(Exception ex)
        {
            //var hashCode = this.logger.GetHashCode();
            this.logger.Log(LogLevel.Error, ex, "Unhandled Error");

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var errorMessage = new ErrorResponse { Message = exception.Message};


            var result = JsonConvert.SerializeObject(errorMessage);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
