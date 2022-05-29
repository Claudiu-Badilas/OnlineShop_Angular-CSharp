using Server.Models.OderDTOs;
using Server.Repositories.Models;

namespace Server.Repositories.Interfaces {
    public interface IOrderRepository {

        Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
        Task AddOrder(OrderDto order);
        Task<Order> GetOrder(string orderNumber);
    }
}
