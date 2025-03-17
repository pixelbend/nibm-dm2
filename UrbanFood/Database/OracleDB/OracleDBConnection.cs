using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace UrbanFood.Database.OracleDB
{
    public sealed class OracleDBConnection
    {
        private static readonly Lazy<OracleDBConnection> _instance =
            new(() => new OracleDBConnection());

        private OracleConnection? _connection;
        private string? _connectionString;

        public static OracleDBConnection Instance => _instance.Value;

        private OracleDBConnection() { }

        public void Initialize(string connectionString)
        {
            if (_connectionString == null)
            {
                _connectionString = connectionString;
            }
        }

        public OracleConnection GetConnection()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                if (_connectionString == null)
                {
                    throw new InvalidOperationException("Connection string is not initialized. Call Initialize() first.");
                }

                _connection = new OracleConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}