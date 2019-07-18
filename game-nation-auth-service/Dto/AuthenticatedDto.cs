namespace game_nation_auth_service.Dto
{
    public class AuthenticatedDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}