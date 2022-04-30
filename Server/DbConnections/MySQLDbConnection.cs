using MySql.Data.MySqlClient;
using System.Data;

namespace Server.DbConnections {
    public class MySQLDbConnection : IMySQLDbConnection {
        private readonly string _connectionString;

        public MySQLDbConnection(string connectionString) {
            _connectionString = connectionString;
        }

        public IDbConnection Connect() {
            return new MySqlConnection(_connectionString);
        }
    }
}
