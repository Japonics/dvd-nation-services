using game_nation_shared.Entities;

namespace game_nation_shared.Services
{
    public class Auth
    {
        private User _user;
        
        public void SetUser(User user)
        {
            this._user = user;
        }

        public User User()
        {
            return this._user;
        }
    }
}