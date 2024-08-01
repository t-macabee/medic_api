﻿using Medic.API.Helpers;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Medic.API.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandler> logger;
        private readonly IHostEnvironment env;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                    : new ApiException(context.Response.StatusCode, ex.Message, "Internal server error");

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }

}