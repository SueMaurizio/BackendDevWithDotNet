using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TechHiveSolutions.Api.Middleware
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check for Authorization header
            if (!context.Request.Headers.TryGetValue("Authorization", out var token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Authorization token is missing.");
                return;
            }

            // Validate token (Replace with real validation)
            if (!IsValidToken(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid token.");
                return;
            }

            // If valid, continue to next middleware
            await _next(context);
        }

        // Dummy validation logic for demo purposes
        private bool IsValidToken(string token)
        {
            // Expecting something like: "Bearer VALID_TOKEN"
            const string validToken = "Bearer VALID_TOKEN";
            return token == validToken;
        }
    }
}
