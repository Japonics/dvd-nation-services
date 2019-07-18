using game_nation_shared.Settings;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace game_nation_shared.Database
{
    public class Mongo
    {
        public readonly IMongoDatabase Database;

        public Mongo(IOptions<DatabaseSettings> databaseConfig)
        {
            var settings = databaseConfig.Value;
            var client = new MongoClient(settings.ConnectionString);
            this.Database = client.GetDatabase(settings.Database);
        }
    }
}
