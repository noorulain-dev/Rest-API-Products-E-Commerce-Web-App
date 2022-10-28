using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WebApp0.data
{
    public class Basket
    {
        public static string DBType = "Basket";
        [BsonId]
        public ObjectId? Id { get; set; }
        public int? UserId { get; set; }
        public List<int>? ProductId { get; set; }
        public String? Type { get; set; } = DBType;
    }
}
