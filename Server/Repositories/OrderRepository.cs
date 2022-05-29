using Server.DbConnections;
using Server.Repositories.Interfaces;
using Server.Repositories.Models;
using Dapper;
using Server.Models.OderDTOs;

namespace Server.Repositories {
    public class OrderRepository : IOrderRepository {
        private readonly MySQLDbConnection _conn;

        public OrderRepository(MySQLDbConnection conn) {
            _conn = conn;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    SELECT DISTINCT
                        o.id as Id, 
                        o.order_number as OrderNumber, 
                        o.date as Date,
                        o.status as Status, 
                        o.total_price as TotalPrice
                    FROM orders  o
                    JOIN users  u  
                    ON o.user_id = u.id
                    WHERE u.id = @userId 
                    ORDER BY o.date DESC";

                return await connection.QueryAsync<Order>(sql, new { userId });
            };
        }

        public async Task AddOrder(OrderDto order) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                        INSERT INTO orders(order_number, date, status, total_price, user_id ) values
                        (@OrderNumber, @Date, @Status, @TotalPrice, @userId)";

                await connection.ExecuteAsync(sql, order);
            };
        }

        public async Task<Order> GetOrder(string orderNumber) {
            using (var connection = _conn.Connect()) {
                connection.Open();
                var sql = @"
                    SELECT DISTINCT
                        o.id as Id, 
                        o.order_number as OrderNumber, 
                        o.date as Date,
                        o.status as Status, 
                        o.total_price as TotalPrice
                    FROM orders o
                    WHERE o.order_number = @orderNumber";

                return await connection.QueryFirstOrDefaultAsync<Order>(sql, new { orderNumber });
            };
        }
    }
}