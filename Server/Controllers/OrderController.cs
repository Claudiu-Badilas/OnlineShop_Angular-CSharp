using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers {
    [Route("api/orders")]
    public class OrderController : BaseController {

        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository orderRepo) {
            _orderRepo = orderRepo;
        }


        [HttpGet("user-orders/{id}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] int id) {
            var orders = await _orderRepo.GetOrdersByUserId(id);
            return Ok(orders);
        }
    }
}
