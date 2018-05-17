using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PH.Site.Utility;
using PH.Site.WebAPI.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PH.Site.WebAPI.Middleware
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            this.next = next;
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
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {
            LogHelper.Error(exception.GetBaseException().ToString());

            Result result = new Result();

            var response = context.Response;
            if (exception is UnauthorizedAccessException)
            {
                result.Error = response.StatusCode = (int)HttpStatusCode.Unauthorized;
                result.Message = "Unauthorized";
            }
            else if (exception is Exception)
            {
                result.Error = response.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Message = "BadRequest";
            }
            else
            {
                result.Error = response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Message = "InternalServerError";
            }
            response.ContentType = "application/json";
            await response.WriteAsync(JsonConvert.SerializeObject(result)).ConfigureAwait(false);
        }
    }
}
