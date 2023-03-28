using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestDogsApplication.Core;
using RestDogsApplication.Models;

namespace RestDogsApplication.Controllers;

[ApiController]
[Route("dogs")]
public class DogsController : ControllerBase
{
    private readonly ILogger<DogsController> _logger;
    private readonly IDogRepository _dogRepository;


    public DogsController(
        ILogger<DogsController> logger,
        IDogRepository dogRepository)
    {
        _logger = logger;
        _dogRepository = dogRepository;
    }

    [HttpGet]
    public async Task<Dog[]> GetDogsAsync()
    {
        _logger.LogInformation("GetDogsAsync is executed");
        return await _dogRepository.GetDogsAsync();
    }

    [HttpPost]
    public async Task CreateDogAsync([FromBody] Dog dog)
    {
        await _dogRepository.CreateDogAsync(dog);
    }


    [HttpDelete("{name}")]
    public async Task CreateDogAsync(string name)
    {
        await _dogRepository.DeleteDogAsync(name);
    }
}
