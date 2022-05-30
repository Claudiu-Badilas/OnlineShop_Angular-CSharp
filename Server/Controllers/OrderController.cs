using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models.OderDTOs;
using Server.Repositories.Interfaces;

namespace Server.Controllers {
    [Authorize]
    [Route("api/orders")]
    public class OrderController : BaseController {

        private readonly IOrderRepository _orderRepo;
        private readonly IUserRepository _userRepo;

        public OrderController(IOrderRepository orderRepo, IUserRepository userRepo) {
            _orderRepo = orderRepo;
            _userRepo = userRepo;
        }

        [HttpGet("user-orders/{id}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] int id) {
            var orders = await _orderRepo.GetOrdersByUserId(id);
            return Ok(orders);
        }

        [HttpPost("order")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDto order) {
            var user = await _userRepo.GetUserById(order.UserId);
            if (user == null) {
                return BadRequest("User doesn't exists.");
            }

            await _orderRepo.AddOrder(order);

            var savedOrder = await _orderRepo.GetOrder(order.OrderNumber);
            if (savedOrder == null) {
                return BadRequest("Your order can not be saved.");
            }

            return Ok(savedOrder);
        }
    }
}
