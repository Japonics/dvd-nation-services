using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using game_nation_auth_service.Dto;
using game_nation_shared.Repositories;
using game_nation_shared.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;

namespace game_nation_auth_service.Services
{
    public class AuthService
    {
        private readonly UsersRepository _usersRepository;
        private readonly AppSettings _appSettings;

        public AuthService(UsersRepository usersRepository, IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
            this._usersRepository = usersRepository;
        }

        public AuthenticatedDto Authenticate(string username, string password)
        {
            var result = new AuthenticatedDto();
            var user = this._usersRepository.GetUserByUsername(username);

            if (user == null)
                return null;

            var userDataPayload = new UserDto()
            {
                Email = user.Email,
                Username = user.Username,
                Role = user.Role
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, userDataPayload.Role),
                    new Claim("user_data", userDataPayload.ToJson()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.Token = tokenHandler.WriteToken(token);

            return result;
        }
    }
}