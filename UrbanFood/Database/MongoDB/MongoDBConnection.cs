using MongoDB.Driver;

namespace UrbanFood.Database.MongoDB
{
    public sealed class MongoDBConnection
    {
        private static readonly Lazy<MongoDBConnection> _instance =
            new(() => new MongoDBConnection());

        private IMongoDatabase? _database;
        private string? _connectionString;
        private string? _databaseName;

        public static MongoDBConnection Instance => _instance.Value;

        private MongoDBConnection() { }

        public void Initialize(string connectionString, string databaseName)
        {
            if (_connectionString == null && _databaseName == null)
            {
                _connectionString = connectionString;
                _databaseName = databaseName;

                var client = new MongoClient(_connectionString);
                _database = client.GetDatabase(_databaseName);
            }
        }

        public IMongoDatabase GetDatabase()
        {
            if (_database == null)
            {
                throw new InvalidOperationException("Database is not initialized. Call Initialize() first.");
            }

            return _database;
        }
    }
}
