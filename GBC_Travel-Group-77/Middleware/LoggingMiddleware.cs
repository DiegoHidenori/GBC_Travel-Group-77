using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GBC_Travel_Group_77.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogInformation($"This is an incoming request: {context.Request.Path}");
                await _next(context);
                _logger.LogInformation($"Response status: {context.Response.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }

}
