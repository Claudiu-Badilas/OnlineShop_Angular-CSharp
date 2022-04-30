using Dapper;
using System.Data;

namespace Server.DbConnections {
    public class MySQLInitializer {

        private const string CREATE_PRODUCTS_TABLE_SQL = @"
            CREATE TABLE IF NOT EXIST Products(
            Id TEXT PRIMARY KEY,
            Name VARCHAR(30) 
            )";

        private readonly MySQLDbConnection _mySqlDbConnection;

        public MySQLInitializer(MySQLDbConnection mySqlDbConnection) {
            _mySqlDbConnection = mySqlDbConnection;
        }

        public void Initialize() {
            using (IDbConnection connection = _mySqlDbConnection.Connect()) {
                var data = connection.Execute(CREATE_PRODUCTS_TABLE_SQL);
            };
        }
    }
}
