using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RestDogsApplication.Core;
using RestDogsApplication.Core.Filters;
using RestDogsApplication.Infrastructure;
using System;

namespace RestDogsApplication;

public class Program
{
    public static void Main(string[] args)
    {
       
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.Configure<AppConfiguration>(builder.Configuration);

        builder.Services.AddLocalization();
        builder.Services.AddMvc(options =>
        {
            options.Filters.Add<LoggerFilter>();
            options.Filters.Add<ExceptionFilter>();
        });

        builder.Services.AddCors();

        string value1 = builder.Configuration.GetSection("Logging").GetSection("LogLevel").GetSection("Default").Value;
        string value2 = builder.Configuration["ConnectionString"];

        //Custom Dependencies.
        builder.Services.AddScoped<NumberGenerator>();
        builder.Services.AddSingleton<IDogRepository, InMemoryDogRepository>();

        var app = builder.Build();

        app.UseRequestLocalization();

        //Middelwares
        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.MapControllers();

        app.Run();
    }
}
