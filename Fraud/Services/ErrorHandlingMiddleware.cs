using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Fraud.Services
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger logger)
        {
            //var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            //if (ex is NotFoundException) code = HttpStatusCode.NotFound;
            //else if (ex is UnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is BadRequestException) code = HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)code;
            //if (ex.InnerException != null)
            //    ex = ex.InnerException;
            //if (code != HttpStatusCode.InternalServerError && code != HttpStatusCode.Unauthorized)
            context.Response.WriteAsync(JsonConvert.SerializeObject(new { mes = ex.Message, innMess = ex.InnerException?.Message, stack = ex.StackTrace }));
            //logger.LogError(ex, "{Url}" + "{RequestGuid}", context.Request.GetDisplayUrl(), context.Items["RequestGuid"].ToString());
            return context.Response.CompleteAsync();// .WriteAsync(JsonResolt);
        }
    }
}
