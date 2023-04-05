using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestDogsApplication.Core;
using RestDogsApplication.Models;

namespace RestDogsApplication.Controllers;

[ApiController]
[Route("dogs")]
public class DogsController : ControllerBase
{
    private readonly IDogRepository _dogRepository;

    public DogsController(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetDogsAsync()
    {
        return Ok(await _dogRepository.GetDogsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateDogAsync([FromBody] Dog dog)
    {
        await _dogRepository.CreateDogAsync(dog);
        return StatusCode(201);
    }

    [HttpDelete()]
    public async Task<IActionResult> DeleteDogByNameAsync([FromQuery] string id, [FromQuery] string name)
    {
        await _dogRepository.DeleteDogAsync(name);
        return NoContent();
    }

    [HttpDelete("second")]
    public Task DeleteDogSecondAsync([FromBody] DeleteDogRequest deleteDog)
    {
        return _dogRepository.DeleteDogAsync(deleteDog.Name);
    }
}
