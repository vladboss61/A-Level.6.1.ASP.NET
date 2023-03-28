using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RestDogsApplication.Core;

public sealed class Sample1Middleware
{
    private readonly RequestDelegate _next;

    public Sample1Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //1
        string displayName = context.GetEndpoint()?.DisplayName;
        Console.WriteLine(displayName);
        // 1

        //To add Headers AFTER everything you need to do this
        context.Response.OnStarting(() => {
            context.Response.Headers.Add("X-Response-Custom-Header", "Data in Header");
            return Task.CompletedTask;
        });

        await _next(context);
        //4
        //4
    }
}
