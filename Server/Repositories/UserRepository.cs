using Dapper;
using Server.DbConnections;
using Server.Models;
using Server.Repositories.Interfaces;
using System.Data;

namespace Server.Repositories {
    public class UserRepository : IUserRepository {
        private readonly MySQLDbConnection _conn;

        public UserRepository(MySQLDbConnection conn) {
            _conn = conn;
        }

        public async Task<bool> IsExistingUser(string email) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"SELECT email FROM users WHERE email = @email;";

                return (await connection.QueryAsync<string>(sql, new { email })).ToList().Count > 0;
            };
        }

        public async Task<AppUser> GetUserById(long userId) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    SELECT DISTINCT 
                        u.id as Id, 
                        u.username as UserName,
                        u.password_hash as PasswordHash,
                        u.password_salt as PasswordSalt,
                        u.email_address as EmailAddress,
                        u.first_name as FirstName,
                        u.last_name as LastName,
                        u.join_date as JoinDate,
                        u.last_login as LastLogin,
                        u.active as IsActive,
                        u.role_id as split,
                        r.id as Id, 
                        r.name as Name
                    FROM users u 
                    JOIN roles r ON u.role_id = r.id";
                return (await connection.QueryAsync<AppUser>(sql, new { userId })).ToList().Find(u => u.Id == userId);
            };
        } public async Task<AppUser> GetUserByEmail(string email) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    SELECT DISTINCT 
                        u.id as Id, 
                        u.password_hash as PasswordHash,
                        u.password_salt as PasswordSalt,
                        u.email as Email,
                        u.join_date as JoinDate,
                        u.last_login as LastLogin,
                        u.is_active as IsActive,
                        r.id as RoleId, 
                        r.role_name as RoleName
                    FROM users u 
                    JOIN roles r ON u.role_id = r.id
                    WHERE u.email = @email";
                return (await connection.QueryAsync<AppUser>(sql, new { email })).FirstOrDefault();
            };
        }

        public async Task AddUser(AppUser user) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    INSERT INTO users 
                        (email, password_hash, password_salt, join_date, last_login, is_active, role_id) 
                    VALUES
                        (@Email, @PasswordHash, @PasswordSalt, @JoinDate, @LastLogin, @IsActive, @RoleId)";

                await connection.ExecuteAsync(sql, user);
            };
        }


    }
}
