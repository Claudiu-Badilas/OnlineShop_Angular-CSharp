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

        public Task<Category> AddCategory(string name) {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(int categoryId, string name) {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int categoryId) {
            throw new NotImplementedException();
        }

    }
}
