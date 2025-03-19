using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace UrbanFood.Database.MongoDB
{
    class ReviewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("ProductID")]
        public required string ProductID { get; set; }

        [BsonElement("CustomerID")]
        public required string CustomerID { get; set; }

        [BsonElement("Content")]
        public required string Content { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
