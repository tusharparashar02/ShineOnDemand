using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Interface;
using Backend.BusinessLayer.Services;
using Backend.DTO.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly AssignOrderService _assignOrderService;
        private readonly UserService _userService;

        public AdminController(AssignOrderService assignOrderService, UserService userService)
        {
            _assignOrderService = assignOrderService;
            _userService = userService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _assignOrderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _assignOrderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound(new { message = "Order not found" });

            return Ok(order);
        }

        [HttpPut("{orderId}/assign/{washerId}")]
        public async Task<ActionResult<Order>> AssignOrderToWasher(int orderId, string washerId)
        {
            var order = await _assignOrderService.AssignOrderToWasherAsync(orderId, washerId);
            if (order == null) return BadRequest(new { message = "Order not found or invalid washer ID" });

            return Ok(new { message = "Order assigned successfully", order });
        }
        [HttpGet("washers")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllWashers()
        {
            var washers = await _userService.GetAllWashersAsync();
            return Ok(washers);
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllCustomers()
        {
            var customers = await _userService.GetAllCustomersAsync();
            return Ok(customers);
        }


    }

}