using System;
using System.Security.Cryptography;
using System.Text;
using game_nation_auth_service.Dto;
using game_nation_auth_service.Entities;
using game_nation_auth_service.Repositories;

namespace game_nation_auth_service.Services
{
    public class UsersService
    {
        public readonly UsersRepository _usersRepository;

        public UsersService(UsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }
        
        public void RegisterUser(RegisterRequestDto requestDto)
        {
            if (requestDto.Password != requestDto.ConfirmPassword)
                throw new Exception("Hasła się nie zgadzają!");
            
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.UTF8.GetBytes(requestDto.Password));

            var user = new User()
            {
                Email = requestDto.Email,
                Password = Encoding.UTF8.GetString(md5data),
                Username = requestDto.Username
            };

            this._usersRepository.StoreUser(user);
        }
    }
}