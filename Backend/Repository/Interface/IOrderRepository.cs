using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);

    }
}
