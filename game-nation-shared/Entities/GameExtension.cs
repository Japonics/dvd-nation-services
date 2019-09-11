using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_nation_shared.Entities
{
    public class GameExtension
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("game_id")]
        public string GameId { get; set; }
        
        [BsonElement("long_description")]
        public string LongDescription { get; set; }
        
        [BsonElement("cover_image")]
        public string CoverImage { get; set; }
        
        [BsonElement("price")]
        public float Price { get; set; }
        
        [BsonElement("category_id")]
        public string CategoryId { get; set; }
        
        [BsonElement("requirements")]
        public string Requirements { get; set; }
    }
}