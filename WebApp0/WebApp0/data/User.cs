using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp0.data
{
    public class User
    {
        public static string DBType = "User";
        [BsonId]
        public ObjectId? Id { get; set; }

        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Type { get; set; } = DBType;
    }
}
