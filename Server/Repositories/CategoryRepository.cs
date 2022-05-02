using Dapper;
using Server.DbConnections;
using Server.Repositories.Interfaces;
using Server.Repositories.Models;

namespace Server.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly MySQLDbConnection _conn;

        public CategoryRepository(MySQLDbConnection conn) {
            _conn = conn;
        }

        public async Task<IEnumerable<Category>> GetCategories() {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    SELECT DISTINCT  
                        c.id as Id, 
                        c.name as Name
                    FROM categories c";

                return await connection.QueryAsync<Category>(sql);
            };
        }

        public async Task AddCategory(string name) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"INSERT INTO categories (name) values (@name)";

                await connection.ExecuteAsync(sql, new { name });
            };
        }

        public async Task UpdateCategory(int categoryId, string name) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"UPDATE categories c SET c.name = @name WHERE c.id = @categoryId";

                await connection.ExecuteAsync(sql, new { categoryId, name });
            };
        }

        public async void DeleteCategory(int categoryId) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"DELETE FROM categories WHERE id = @categoryId";

                await connection.ExecuteAsync(sql, new { categoryId });
            };
        }

    }
}
