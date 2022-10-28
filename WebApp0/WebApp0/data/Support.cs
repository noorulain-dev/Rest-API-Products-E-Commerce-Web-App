using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp0.data
{
    public class Support
    {
        public static string DBType = "Support";
        [BsonId]
        public ObjectId? Id { get; set; }
        public int? SupportId { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; } = DBType;

    }
}
