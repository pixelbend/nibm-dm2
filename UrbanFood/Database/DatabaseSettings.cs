namespace UrbanFood.Database
{
    public static class DatabaseSettings
    {
        public static string OracleDBConnectionString =>
            "User Id=urban_food_db;Password=urban_food_db;Data Source=localhost:1521/UFDB";

        public static string MongoDBConnectionString =>
            "mongodb://urban_food_db:urban_food_db@localhost:27017";

        public static string MongoDBDatabaseName => "UFDB";
    }
}
