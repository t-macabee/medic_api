using Medic.API.Helpers;
using System.Net;
using System.Text.Json;

namespace Medic.API.Middleware
{
    public class ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IHostEnvironment env)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandler> _logger = logger;
        private readonly IHostEnvironment _env = env;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred while processing the request.");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                    : new ApiException(context.Response.StatusCode, "An unexpected error occurred. Please try again later.", "Internal server error");

                var json = JsonSerializer.Serialize(response, JsonSerializerOptions);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
