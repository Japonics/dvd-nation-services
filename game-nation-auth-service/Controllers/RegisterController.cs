using game_nation_auth_service.Dto;
using game_nation_auth_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace game_nation_auth_service.Controllers
{
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly UsersService _usersService;
        
        public RegisterController(UsersService usersService)
        {
            this._usersService = usersService;
        }
        
        [Route("api/auth/register")]
        [HttpPost]
        public ActionResult Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            this._usersService.RegisterUser(registerRequestDto);

            return Ok();
        }
    }
}