using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using game_nation_shared.Repositories;
using game_nation_shared.Services;
using game_nation_shared.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace game_nation_shared.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;

        public AuthMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            this._secret = appSettings.Value.Secret;
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext, Auth auth, UsersRepository usersRepository)
        {
            var tokenHeaderValue = httpContext.Request.Headers["Authorization"].ToString();
            tokenHeaderValue = tokenHeaderValue.Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._secret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            tokenHandler.ValidateToken(tokenHeaderValue, validationParameters, out var securityToken);
            var userIdClaims = (securityToken as JwtSecurityToken)?.Claims.FirstOrDefault(x => x.Type == "unique_name");
            
            if (userIdClaims == null)
                throw new AuthenticationException();

            var userId = userIdClaims.Value;
            
            var user = usersRepository.GetUserById(userId);
            
            if (user == null)
                throw new AuthenticationException();
            
            auth.SetUser(user);
            
            await _next.Invoke(httpContext);
        }
    }
}