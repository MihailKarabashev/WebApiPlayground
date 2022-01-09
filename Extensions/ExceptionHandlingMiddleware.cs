namespace WebApiPlayground.Extensions
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using static Common.CustomExceptions;

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }


    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
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

        private static async Task HandleExceptionAsync(HttpContext httpContext , Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var errorDetails = new ErrorDetails()
            {
                Message = exception.Message,
                StatusCode = httpContext.Response.StatusCode
            };

            await httpContext.Response.WriteAsync(errorDetails.ToString());
        }
    }

}
