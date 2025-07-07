using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Interface;
using Backend.BusinessLayer.Services;
using Backend.DTO.Order;
using Backend.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN, Washer")]
    public class WasherOrderController : ControllerBase
    {
        private readonly WasherOrderService _washerOrderService;

        public WasherOrderController(WasherOrderService washerOrderService)
        {
            _washerOrderService = washerOrderService;
        }

        [HttpGet("{washerId}/orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByWasherId(string washerId)
        {
            var orders = await _washerOrderService.GetOrdersByWasherIdAsync(washerId);
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrderById(int orderId)
        {
            var order = await _washerOrderService.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound(new { message = "Order not found" });

            return Ok(order);
        }

        [HttpPut("{orderId}/status")]
        public async Task<ActionResult<Order>> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusDTO updateOrder)
        {
            if (updateOrder.Status != "ACCEPTED" && updateOrder.Status != "DECLINED" && updateOrder.Status != "COMPLETED")
                return BadRequest(new { message = "Invalid status. Allowed: ACCEPTED or DECLINED" });

            var order = await _washerOrderService.UpdateOrderStatusAsync(orderId, updateOrder.Status, updateOrder.Comment);
            if (order == null) return NotFound(new { message = "Order not found" });

            return Ok(new { message = "Order updated successfully", order });
        }
    }

}