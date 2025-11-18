using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TechHiveSolutions.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log request information
            var method = context.Request.Method;
            var path = context.Request.Path;

            await _next(context); // Execute next middleware

            // Log response status
            var statusCode = context.Response.StatusCode;

            _logger.LogInformation("HTTP Request: {method} {path} => {statusCode}",
                method, path, statusCode);
        }
    }
}
