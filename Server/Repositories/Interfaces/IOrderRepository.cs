using Server.Repositories.Models;

namespace Server.Repositories.Interfaces {
    public interface IOrderRepository {

        Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
    }
}
