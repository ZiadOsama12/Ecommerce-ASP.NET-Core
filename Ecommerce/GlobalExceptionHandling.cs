using Api.Domain;
using Api.Domain.Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Ecommerce
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        //To use your exception handler for fluent validation,
        // you need to make FluentValidation throw an exception.


        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            _logger.LogError($"Something went wrong:");
            _logger.LogError(exception.ToString());

            //var message = exception switch
            //{
            //    AccessViolationException => "Access violation exception",
            //    _ => "Internal Server Error from IExceptionHandler."
            //};
            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => (int) HttpStatusCode.BadRequest,
                _ => (int) HttpStatusCode.InternalServerError
            };
            
            await httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message
            }.ToString());
            return true;
        }
    }
}
