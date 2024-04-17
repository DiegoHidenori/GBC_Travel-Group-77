using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace GBC_Travel_Group_77.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                _logger.LogInformation("Executing action {Action} on controller {Controller}", context.ActionDescriptor.DisplayName, context.Controller.GetType().Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                _logger.LogInformation("Executed action {Action} on controller {Controller}", context.ActionDescriptor.DisplayName, context.Controller.GetType().Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
