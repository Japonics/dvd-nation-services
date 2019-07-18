using System.Collections.Generic;
using game_nation_shared.Database;
using game_nation_shared.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace game_nation_shared.Repositories
{
    public class UsersRepository
    {
        private readonly IMongoDatabase _database;
        private const string UsersCollection = "users";
        
        public UsersRepository(Mongo database)
        {
            this._database = database.Database;
        }
        
        public User GetUserById(string id)
        {
            var users = this._database.GetCollection<User>(UsersCollection);
            return users.Find(x => x.Id == id).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            var users = this._database.GetCollection<User>(UsersCollection);
            return users.Find(x => x.Username == username).FirstOrDefault();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = this._database.GetCollection<User>(UsersCollection);
            return users.Find(x => x.Id != null).ToList();
        }
        
        public void StoreUser(User user)
        {
            var users = this._database.GetCollection<User>(UsersCollection);
            users.InsertOne(user);
        }

        public void UpdateUser(User user)
        {
            var users = this._database.GetCollection<User>(UsersCollection);
            var filter = Builders<User>.Filter.Eq("_id", BsonObjectId.Create(user.Id));
            var update = Builders<User>.Update
                .Set("username", user.Username);
            
            users.UpdateOne(filter, update);
        }
    }
}