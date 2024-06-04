using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.App.Middlewares;

public class AuthenticationMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, IUserRepository userRepository)
    {
        var user = context.Items["User"];
        if (user is null or not User)
            await ReturnErrorResponse(context);
        else
            await next(context);
    }

    private static async Task ReturnErrorResponse(HttpContext context)
    {
        context.Response.StatusCode = 403;
        context.Response.ContentType = "application/json";
        await context.Response.StartAsync();
    }
}

public static class AuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthenticationMiddleware(
        this IApplicationBuilder builder)
    {
        builder.UseRouting();

        builder.UseAuthentication();


        builder.UseWhen(context => context.Request.Path.StartsWithSegments("/api/Vehicle"),
            appBuilder => { appBuilder.UseMiddleware<AuthenticationMiddleware>(); });

        return builder;
    }
}