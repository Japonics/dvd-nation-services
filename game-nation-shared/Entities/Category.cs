﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace game_nation_shared.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("description")]
        public string Description { get; set; }
        
        [BsonElement("cover_image")]
        public string CoverImage { get; set; }
    }
}
