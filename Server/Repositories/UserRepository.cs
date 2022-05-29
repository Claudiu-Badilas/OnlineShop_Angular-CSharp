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

        public async Task<AppUser> GetUser(string username) {
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
                return (await connection.QueryAsync<AppUser, Role, AppUser>(sql, (user, role) => {
                    user.Role = role;
                    return user;
                }, splitOn: "split")).ToList().Find(u => u.UserName == username);
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
                return (await connection.QueryAsync<AppUser, Role, AppUser>(sql, (user, role) => {
                    user.Role = role;
                    return user;
                }, splitOn: "split")).ToList().Find(u => u.Id == userId);
            };
        }

        public async Task AddUser(AppUser user) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    INSERT INTO 
                        users (username, email_address, password_hash, password_salt, first_name, last_name, join_date, last_login, active, role_id) values
                        (@UserName, @EmailAddress, @PasswordHash, @PasswordSalt, @FirstName, @LastName, @JoinDate, @LastLogin, @IsActive, @RoleId)";

                await connection.ExecuteAsync(sql, user);
            };
        }

       
    }
}
