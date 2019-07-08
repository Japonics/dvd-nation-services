using MongoDB.Driver;
using game_nation_auth_service.Settings;

namespace game_nation_auth_service.Database
{
    public class Mongo
    {
        public readonly IMongoDatabase database;

        public Mongo(DatabaseSettings settings)
        {
            var _client = new MongoClient(settings.ConnectionString);
            this.database = _client.GetDatabase(settings.Database);
        }
    }
}
