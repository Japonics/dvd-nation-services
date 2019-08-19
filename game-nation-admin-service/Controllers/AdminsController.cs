using System.Collections.Generic;
using game_nation_admin_service.Dto;
using game_nation_shared.Models;
using game_nation_shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace game_nation_admin_service.Controllers
{
    [ApiController]
    [Route("api/admin/admins")]
    public class AdminsController : ControllerBase
    {
        private readonly UsersRepository _usersRepository;

        public AdminsController(UsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        [Route("")]
        public ActionResult<IEnumerable<UserDto>> GetAdmins()
        {
            var admins = this._usersRepository.GetAdmins();
            return Ok(admins);
        }

        [Route("{userId}")]
        [HttpPut]
        public ActionResult SetAdminRole(string userId)
        {
            this._usersRepository.ChangeIsAdminRole(userId, Roles.ADMIN);
            return Ok();
        }

        [Route("{userId}")]
        [HttpDelete]
        public ActionResult UnsetAdminRole(string userId)
        {
            this._usersRepository.ChangeIsAdminRole(userId, Roles.USER);
            return Ok();
        }
    }
}