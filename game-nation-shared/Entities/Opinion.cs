using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_nation_shared.Entities
{
    public class Opinion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        public string UserId { get; set; }

        [BsonElement("game_id")]
        public string GameId { get; set; }
        
        [BsonElement("rate")]
        public int Rate { get; set; }

        [BsonElement("comment")]
        public string Comment { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}