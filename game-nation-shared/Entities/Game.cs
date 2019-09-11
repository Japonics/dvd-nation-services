using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_nation_shared.Entities
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }
        
        [BsonElement("short_description")]
        public string ShortDescription { get; set; }
        
        [BsonElement("price")]
        public float Price { get; set; }
        
        [BsonElement("category_id")]
        public string CategoryId { get; set; }
        
        [BsonElement("game_avatar")]
        public string GameAvatar { get; set; }
    }
}