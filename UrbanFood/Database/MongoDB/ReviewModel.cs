using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace UrbanFood.Database.MongoDB
{
    class ReviewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("product_id")]
        public required string ProductId { get; set; }

        [BsonElement("customer_id")]
        public required string CustomerId { get; set; }

        [BsonElement("content")]
        public required string Content { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
