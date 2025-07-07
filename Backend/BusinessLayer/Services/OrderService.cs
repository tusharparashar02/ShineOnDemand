using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Interface;
using Backend.Context;
using Backend.DTO.Order;
using Backend.Repository.Interface;
using Backend.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Services
{
    // OrderService.cs

    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
    

            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            return order != null ? _mapper.Map<OrderDTO>(order) : null;
        }

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.Status = "PENDING"; // Default status on order creation
            var newOrder = await _orderRepository.AddOrderAsync(order);
            return _mapper.Map<OrderDTO>(newOrder);
        }

        public async Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var updatedOrder = await _orderRepository.UpdateOrderAsync(order);
            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await _orderRepository.DeleteOrderAsync(orderId);
        }
        


    }

}
