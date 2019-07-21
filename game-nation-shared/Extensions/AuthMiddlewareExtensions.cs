using game_nation_shared.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace game_nation_shared.Extensions
{
    public static class AuthMiddlewareExtensions
    {

        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}