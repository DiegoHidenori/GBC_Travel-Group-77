using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GBC_Travel_Group_77.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred...");
                //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (ex is NotFoundException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Response.Redirect("NotFound");
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.Redirect("Error");
                }

                await context.Response.WriteAsync("An unexpected error occurred...");
            }
        }
    }
}
