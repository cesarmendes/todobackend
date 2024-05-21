using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using System.Net;
using TodoList.Infrastructure.Data.Contexts;
using System.Text.Json;

namespace TodoList.Api.Extensions
{
    public static class GlobalExceptionExtension
    {
        public static void UseGlobalExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    if (context.Features.Get<IExceptionHandlerFeature>() is IExceptionHandlerFeature exceptionHandlerFeature)
                    {
                        var guid = Guid.NewGuid();

                        app.Logger.LogError(exceptionHandlerFeature.Error, "Error occure while processing the request {Method}{Path} TraceiId: {TraceId}", context.Request.Method, exceptionHandlerFeature.Path, guid);

                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = MediaTypeNames.Application.Json;

                        var problemDetails = new ProblemDetails()
                        {
                            Detail = $"Internal server error occured, TraceId: {guid}",
                            Instance = exceptionHandlerFeature.Path,
                            Status = context.Response.StatusCode,
                            Title = "Internal Server Error",
                            Type = exceptionHandlerFeature.Error.GetType().Name,
                        };

                        var json = JsonSerializer.Serialize(problemDetails);

                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
