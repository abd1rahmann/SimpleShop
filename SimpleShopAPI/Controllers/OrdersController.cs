using BusinessLogicLayer.Services.Orders;
using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SimpleShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] CreateOrderDto dto)
        {
            var order = await _orderService.CreateOrderAsync(dto);
            return order == null
                ? BadRequest("Invalid order: check product IDs and stock.")
                : CreatedAtAction(nameof(GetAll), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDto dto)
        {
            var success = await _orderService.UpdateOrderAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _orderService.DeleteOrderAsync(id);
            return success ? NoContent() : NotFound();
        }
    }

}
