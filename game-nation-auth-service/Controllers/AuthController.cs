using game_nation_auth_service.Dto;
using game_nation_auth_service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace game_nation_auth_service.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService userService)
        {
            _authService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]CredentialsDto userParam)
        {
            var authenticated = _authService.Authenticate(userParam.Username, userParam.Password);

            if (authenticated == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(authenticated);
        }
    }
}