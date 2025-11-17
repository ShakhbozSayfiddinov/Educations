using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EducationCenter.Api.Middlewares;

internal static class EducationExceptionMiddleware
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (exceptionFeature == null)
                    return;

                var ex = exceptionFeature.Error;
                var statusCode = ex switch
                {
                    KeyNotFoundException => HttpStatusCode.NotFound,
                    UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                    ArgumentException => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                };

                var problem = new ProblemDetails
                {
                    Status = (int)statusCode,
                    Title = ex.GetType().Name,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                };

                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = (int)statusCode;
                await context.Response.WriteAsJsonAsync(problem).ConfigureAwait(false);
            });
        });
    }
}
