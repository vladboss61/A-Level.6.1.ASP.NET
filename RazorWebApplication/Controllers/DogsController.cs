using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RazorWebApplication.Controllers;

public class DogsController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        client.BaseAddress = new System.Uri("http://localhost:5072/");

        HttpResponseMessage dogsResponse = (await client.GetAsync("dogs"));
        Dog[] dogsResponseContent = JsonSerializer.Deserialize<Dog[]>(await dogsResponse.Content.ReadAsStringAsync());

        DogViewModel[] dogsViewModel = dogsResponseContent.Select(x => new DogViewModel { Name = x.Name, Type = x.Info }).ToArray();

        var view = View(dogsViewModel);

        view.ViewData["Test"] = "ViewDataTest";

        return view;
    }
}
