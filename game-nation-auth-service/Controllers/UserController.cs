using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace game_nation_auth_service.Controllers
{
    [Authorize]
    public class UserController : ControllerBase
    {
        
    }
}