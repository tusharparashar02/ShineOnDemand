using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Interface;
using Backend.BusinessLayer.Services;
using Backend.DTO.Order;
using Backend.Repository.Interface;
using Backend.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN, Customer, Washer")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(OrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            _logger.LogInformation("Fetching all orders...");
            var orders = (await _orderService.GetAllOrdersAsync()).ToList(); 

            return orders.Any() ? Ok(orders) : NoContent(); 
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int orderId)
        {
            _logger.LogInformation($"Fetching order with ID: {orderId}");
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return order != null ? Ok(order) : NotFound(new { message = "Order not found" });
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderDTO orderDto)
        {
            if (orderDto == null || string.IsNullOrEmpty(orderDto.CarNumber))
                return BadRequest(new { message = "Invalid order data or missing CarNumber" });

            _logger.LogInformation($"Placing order for car: {orderDto.CarNumber}");
            var newOrder = await _orderService.AddOrderAsync(orderDto);
            return Ok(newOrder);

        }

        [HttpPut]
        public async Task<ActionResult<OrderDTO>> UpdateOrder([FromBody] OrderDTO orderDto)
        {
            if (orderDto == null)
                return BadRequest(new { message = "Invalid order data" });

            _logger.LogInformation($"Updating order: {orderDto.CarNumber}");
            var updatedOrder = await _orderService.UpdateOrderAsync(orderDto);
            return Ok(updatedOrder);
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            _logger.LogInformation($"Deleting order with ID: {orderId}");
            var result = await _orderService.DeleteOrderAsync(orderId);
            return result ? NoContent() : NotFound(new { message = "Order not found" });
        }
    }
}
