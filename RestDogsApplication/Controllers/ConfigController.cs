using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestDogsApplication.Core;
using RestDogsApplication.Infrastructure;

namespace RestDogsApplication.Controllers;

[ApiController]
[Route("config")]
public class ConfigController : ControllerBase
{
    private readonly NumberGenerator _generator;
    private readonly ILogger<ConfigController> _logger;
    private readonly AppConfiguration _appConfiguration;

    public ConfigController(
        NumberGenerator generator,
        ILogger<ConfigController> logger,
        IOptions<AppConfiguration> options)
    {
        _generator = generator;
        _logger = logger;
        _appConfiguration = options.Value;
    }

    [HttpGet]
    public IActionResult GetConfig()
    {
        var number = _generator.GetNumber();

        //Some logic with number.

        if (_appConfiguration.LogState == "Error")
        {
            _logger.LogCritical("RandomNumberController::GetConfig is executed.");
        }
        else
        {
            _logger.LogInformation("RandomNumberController::GetConfig is executed Info.");
        }

        return Ok(_appConfiguration);
    }
}
