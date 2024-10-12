
using System.Text.Json;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace Ocorpus.AuthorizationService.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (KeyNotFoundException e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = e.Message,
                Status = StatusCodes.Status404NotFound,
                #if DEBUG
                Detail = e.StackTrace
                #endif
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/problem+json";
            ProblemDetails problemDetails = new ProblemDetails { Title = e.Message, Status = 500 };
            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
        return;
    }
}
