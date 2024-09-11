using full_ecommerce.Data.Models;
using full_ecommerce.DTO;
using full_ecommerce.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace full_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            var order = new Ordere
            {
                Id = Guid.NewGuid(),
              
                UserId = orderDto.UserId,
                TotalPrice = orderDto.TotalPrice,
                OrderDate = DateTime.UtcNow,
               Addressid = orderDto.Addressid,
               OrdersPrice = orderDto.OrdersPrice,
                PriceDelivery = orderDto.PriceDelivery,
                PaymentMethod = orderDto.PaymentMethod,
                OrdrsType = orderDto.OrdrsType,
               
             
            };

            await _orderRepository.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderDto orderDto)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null) return NotFound();

            order.UserId = orderDto.UserId;
            order.TotalPrice = orderDto.TotalPrice;
            order.OrderDate = DateTime.UtcNow;
            order.Addressid = orderDto.Addressid;
            
            order.PriceDelivery = orderDto.PriceDelivery;
            order.PaymentMethod = orderDto.PaymentMethod;
            order.OrdrsType = orderDto.OrdrsType;
            order.OrdersPrice = orderDto.OrdersPrice;



            await _orderRepository.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var success = await _orderRepository.DeleteOrderAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
