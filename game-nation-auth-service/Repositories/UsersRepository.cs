using game_nation_auth_service.Database;
using game_nation_auth_service.Entities;
using MongoDB.Driver;

namespace game_nation_auth_service.Repositories
{
    public class UsersRepository
    {
        private readonly IMongoDatabase _database;
        
        public UsersRepository(Mongo database)
        {
            this._database = database.database;
        }
        
        public void StoreUser(User user)
        {
            var users = this._database.GetCollection<User>("users");
            users.InsertOne(user);
        }
    }
}