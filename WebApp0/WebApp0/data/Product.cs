using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp0.data
{
    public class Product
    {
        public static string DBType = "Product";
        [BsonId]
        public ObjectId? Id { get; set; }
        public string? Name { get; set; }
        public int? ProductId { get; set; }
        public double? Price { get; set; }
        public string? Type { get; set; } = DBType;
    }
}
