var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// Add custom middleware to pipeline
app.UseMiddleware<TechHiveSolutions.Api.Middleware.ErrorHandlingMiddleware>();
app.UseMiddleware<TechHiveSolutions.Api.Middleware.TokenValidationMiddleware>();
app.UseMiddleware<TechHiveSolutions.Api.Middleware.RequestLoggingMiddleware>();

app.MapControllers();

app.Run();
