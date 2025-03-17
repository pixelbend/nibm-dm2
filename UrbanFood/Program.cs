using UrbanFood.Database;
using UrbanFood.Database.MongoDB;
using UrbanFood.Database.OracleDB;
using UrbanFood.Forms;

namespace UrbanFood
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            OracleDBConnection.Instance.Initialize(DatabaseSettings.OracleDBConnectionString);
            MongoDBConnection.Instance.Initialize(DatabaseSettings.MongoDBConnectionString, DatabaseSettings.MongoDBDatabaseName);

            Application.Run(new RoleSelection());
        }
    }
}