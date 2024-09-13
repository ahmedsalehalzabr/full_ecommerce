using full_ecommerce.Data.Models;
using full_ecommerce.DTO;
using full_ecommerce.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
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
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOrder( Guid userId)
        //{
        //    var order = await _orderRepository.GetOrderByIdAndUserIdAsync( userId);
        //    if (order == null) return NotFound();

        //    return Ok(order);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(id);
            if (orders == null || !orders.Any()) return NotFound();

            return Ok(orders);
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder(Guid id, Guid userId)
        //{
        //    var success = await _orderRepository.DeleteOrderByIdAndUserIdAsync(id, userId);
        //    if (!success) return NotFound();

        //    return NoContent();
        //}

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
                Status = orderDto.Status,
                OrdrsType = orderDto.OrdrsType,
                Item = orderDto.Item,
                Quantity = orderDto.Quantity,
                Price = orderDto.Price,
               
             
            };

            await _orderRepository.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
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
