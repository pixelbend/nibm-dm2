using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace UrbanFood.Database.MongoDB
{
    public class ReviewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("ProductID")]
        public required string ProductID { get; set; }

        [BsonElement("CustomerID")]
        public required string CustomerID { get; set; }

        [BsonElement("Content")]
        public required string Content { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public sealed class ReviewCollection
    {
        private static readonly Lazy<ReviewCollection> _instance = new Lazy<ReviewCollection>(() => new ReviewCollection());

        private readonly IMongoCollection<ReviewModel> _reviewsCollection;

        private ReviewCollection()
        {
            var database = MongoDBConnection.Instance.GetDatabase();
            _reviewsCollection = database.GetCollection<ReviewModel>("Reviews");

            CreateIndexes();
        }

        public static ReviewCollection Instance => _instance.Value;

        private void CreateIndexes()
        {
            var indexKeys = Builders<ReviewModel>.IndexKeys.Text(r => r.Content);
            var indexOptions = new CreateIndexOptions { Name = "ContentTextIndex" };
            _reviewsCollection.Indexes.CreateOne(new CreateIndexModel<ReviewModel>(indexKeys, indexOptions));

            var uniqueIndexKeys = Builders<ReviewModel>.IndexKeys.Ascending(r => r.ProductID).Ascending(r => r.CustomerID);
            var uniqueIndexOptions = new CreateIndexOptions { Unique = true, Name = "ProductCustomerUniqueIndex" };
            _reviewsCollection.Indexes.CreateOne(new CreateIndexModel<ReviewModel>(uniqueIndexKeys, uniqueIndexOptions));
        }

        public IMongoCollection<ReviewModel> GetCollection() => _reviewsCollection;
    }
}
