using Application.Wrappers;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace WebApi.Middleware
{
    /// <summary>
    /// Middleware for handling global, unhandle exceptions, common exceptions etc.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 by default
            ApiResponse<object> response = new ApiResponse<object>(null,exception.Message,false);

            switch (exception)
            {
                case ArgumentOutOfRangeException:
                    code = HttpStatusCode.NotFound;
                    response = new ApiResponse<object>(null, exception.Message, false);
                    break;

                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    response = new ApiResponse<object>(null, exception.Message, false);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
