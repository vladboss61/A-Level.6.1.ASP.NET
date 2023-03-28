using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using RestDogsApplication.Controllers;
using RestDogsApplication.Core;
using RestDogsApplication.Infrastructure;

namespace RestDogsApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.Configure<AppConfiguration>(builder.Configuration);

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession();

        string value1 = builder.Configuration.GetSection("Logging").GetSection("LogLevel").GetSection("Default").Value;
        string value2 = builder.Configuration["ConnectionString"];

        //Dependencies.
        builder.Services.AddScoped<NumberGenerator>();
        builder.Services.AddSingleton<IDogRepository, InMemoryDogRepository>();

        var app = builder.Build();

        app.UseMiddleware<Sample1Middleware>();
        app.UseMiddleware<Sample2Middleware>();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection(); //Middleware 1

        app.UseAuthorization(); //Middleware 2

        app.MapControllers(); //Middleware 3

        app.Run();
    }
}
