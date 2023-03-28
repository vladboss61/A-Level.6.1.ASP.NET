using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RestDogsApplication.Core;

public sealed class Sample2Middleware
{
    private readonly RequestDelegate _next;

    public Sample2Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var accept = context.Request.Headers["Accept-Encoding"];

        Console.WriteLine($"Sample2Middleware example request -> {accept}");

        await _next(context);

        Console.WriteLine("Sample2Middleware example response");
    }
}
