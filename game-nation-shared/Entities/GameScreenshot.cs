using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_nation_shared.Entities
{
    public class GameScreenshot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("game_id")]
        public string GameId { get; set; }
        
        [BsonElement("url")]
        public string Url { get; set; }
    }
}