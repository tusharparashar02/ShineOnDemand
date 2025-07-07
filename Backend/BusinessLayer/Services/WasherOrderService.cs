using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Interface;
using Backend.DTO.Car;
using Backend.DTO.User;
using Backend.Repository.Interface;

namespace Backend.BusinessLayer.Services
{
    public class WasherOrderService
    {
        private readonly IWasherOrderRepository _washerOrderRepository;

        public WasherOrderService(IWasherOrderRepository washerOrderRepository)
        {
            _washerOrderRepository = washerOrderRepository;
        }

        // Get all orders assigned to a specific washer
        public async Task<IEnumerable<Order>> GetOrdersByWasherIdAsync(string washerId)
            => await _washerOrderRepository.GetOrdersByWasherIdAsync(washerId);

        // Get a specific order assigned to a washer by order ID
        public async Task<Order> GetOrderByIdAsync(int orderId)
            => await _washerOrderRepository.GetOrderByIdAsync(orderId);

        // Update the order status (ACCEPTED/DECLINED) and allow washer to provide a comment
        public async Task<Order> UpdateOrderStatusAsync(int orderId, string status, string comment)
            => await _washerOrderRepository.UpdateOrderStatusAsync(orderId, status, comment);
    }

}