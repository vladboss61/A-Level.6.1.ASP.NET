using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestDogsApplication.Core;
using RestDogsApplication.Infrastructure;
using System.Reflection.Emit;

namespace RestDogsApplication.Controllers;

[ApiController]
[Route("random")] //[Route("Random")]
public class RandomNumberController : ControllerBase
{
    private readonly NumberGenerator _generator;
    private readonly ILogger<RandomNumberController> _logger;
    private readonly AppConfiguration _appConfiguration;
    private readonly IConfiguration _configuration;

    public RandomNumberController(
        NumberGenerator generator,
        NumberGenerator generator2,
        ILogger<RandomNumberController> logger,
        IOptions<AppConfiguration> options,
        IConfiguration configuration)
    {
        //Transient/Scoped Example.
        var one = generator.GetNumber();
        var two = generator2.GetNumber();
        
        _generator = generator;
        _logger = logger;
        _appConfiguration = options.Value;
        _configuration = configuration;
        //_configuration["ConnectionString"];
    }

    [HttpGet("{id}/{name}")]
    public int Get(int id, string name)
    {
        _logger.LogInformation("RandomNumberController::Get is executed.");
        return _generator.GetNumber();
    }

    [HttpGet("config")]
    public AppConfiguration GetConfig()
    {
        if (_appConfiguration.LogState == "Error")
        {
            _logger.LogCritical("RandomNumberController::GetConfig is executed.");
        }
        else
        {
            _logger.LogInformation("RandomNumberController::GetConfig is executed Info.");
        }

        return _appConfiguration;
    }
}
