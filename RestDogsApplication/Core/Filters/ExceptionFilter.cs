using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RestDogsApplication.Core.Filters;

public class ExceptionFilter : IAsyncExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        _logger.Log(LogLevel.Information, $"Exception Filter - Message: {context.Exception.Message}");

        switch (context.Exception)
        {
            case InvalidOperationException ex:
                context.Result = new StatusCodeResult(501);
                _logger.Log(LogLevel.Information, $"InvalidOperationException is handled.");
                break;
            default:
                break;
        }

        return Task.CompletedTask;
    }
}
