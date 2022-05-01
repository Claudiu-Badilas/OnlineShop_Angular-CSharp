using Dapper;
using Server.DbConnections;
using Server.Models;
using Server.Repositories.Models;

namespace Server.Repositories.Interfaces {

    public class ProductRepository : IProductRepository {
        private readonly MySQLDbConnection _conn;

        public ProductRepository(MySQLDbConnection conn) {
            _conn = conn;
        }

        public async Task<IEnumerable<Product>> GetProducts() {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    SELECT DISTINCT
                       p.id as Id, 
                       p.name as Name,
                       p.description as Description,
                       p.image as Image,
                       p.price as Price,
                       p.category_id as split,
                       c.id as Id, 
                       c.name as Name
                    FROM products p
                    JOIN categories c ON p.category_id = c.id";

                return await connection.QueryAsync<Product, Category, Product>(sql, (prod, cat) => {
                    prod.Category = cat;
                    return prod;
                }, splitOn: "split");
            };
        }

        public async Task AddProduct(string name, string description, string image, double price, int categoryId) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"INSERT INTO 
                                products (description, image, name, price, category_id) values
                                (@description, @image, @name, @price, @categoryId)";

                await connection.ExecuteAsync(sql, new { description, image, name, price, categoryId });
            };
        }
        
        public async Task UpdateProduct(int productId, string name, string description, string image, double price, int categoryId) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"UPDATE products p
                                SET p.description = @description,
                                    p.image= @image, 
                                    p.name = @name, 
                                    p.price = @price, 
                                    p.category_id = @categoryId
                              WHERE p.id = @productId";

                await connection.ExecuteAsync(sql, new { productId, description, image, name, price, categoryId });
            };
        }

        public async void DeleteProduct(int productId) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"DELETE FROM products WHERE id = @productId";

                await connection.ExecuteAsync(sql, new { productId });
            };
        }
    }
}
