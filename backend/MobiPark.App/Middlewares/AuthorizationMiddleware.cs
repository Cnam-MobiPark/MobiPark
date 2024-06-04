using Microsoft.Extensions.Options;
using MobiPark.App.Helpers;
using MobiPark.App.Models;
using MobiPark.Domain.Interfaces;

namespace MobiPark.App.Middlewares;

public class AuthorizationMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
{
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task Invoke(HttpContext context, IUserRepository userRepository)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        if (token != null)
            AttachUserToContext(context, userRepository, token);

        await next(context);
    }

    private void AttachUserToContext(HttpContext context, IUserRepository userRepository, string token)
    {
        try
        {
            var jwtSession = new JWTSession(token);
            var userId = jwtSession.Validate(_appSettings);

            var user = userRepository.Find(userId);
            context.Items["User"] = user;
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}
public static class AuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthorizationMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthorizationMiddleware>();
    }
}
