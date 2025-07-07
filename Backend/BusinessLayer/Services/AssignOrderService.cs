using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Interface;
using Backend.DTO.Order;
using Backend.Repository.Interface;

namespace Backend.BusinessLayer.Services
{
    public class AssignOrderService
    {
        private readonly IAssignOrderRepository _assignOrderRepository;

        public AssignOrderService(IAssignOrderRepository assignOrderRepository)
        {
            _assignOrderRepository = assignOrderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _assignOrderRepository.GetAllOrdersAsync();

        public async Task<Order> GetOrderByIdAsync(int id) => await _assignOrderRepository.GetOrderByIdAsync(id);

        public async Task<Order> AssignOrderToWasherAsync(int orderId, string washerId)
        {
            var order = await _assignOrderRepository.GetOrderByIdAsync(orderId);
            if (order == null) return null;

            order.WasherId = washerId;
            order.Status = "ACCEPTED";

            return await _assignOrderRepository.UpdateOrderAsync(order);
        }
    }


}