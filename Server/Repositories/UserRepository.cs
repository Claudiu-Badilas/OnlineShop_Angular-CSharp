using Dapper;
using Server.DbConnections;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories {
    public class UserRepository : IUserRepository {
        private readonly MySQLDbConnection _conn;

        public UserRepository(MySQLDbConnection conn) {
            _conn = conn;
        }

        public async Task<AppUser> GetUser(string username) {

            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"SELECT   
                               u.id as Id, 
                               u.username as UserName,
                               u.password_hash as PasswordHash,
                               u.password_salt as PasswordSalt
                           FROM users u WHERE u.username = @username";

                return (await connection.QueryAsync<AppUser>(sql, new { username })).FirstOrDefault();
            };
        }

        public async Task AddUser(string username, byte[] passwordhash, byte[] passwordSalt) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"INSERT INTO 
                                users (username, email_address, password_hash, password_salt) values
                                (@username, @username, @passwordhash, @passwordSalt)";

                await connection.ExecuteAsync(sql, new { username, passwordhash, passwordSalt });
            };
        }


    }
}
