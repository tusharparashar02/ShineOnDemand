using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.User;

namespace Backend.Repository.Interface
{
    public interface IWasherOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersByWasherIdAsync(string washerId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> UpdateOrderStatusAsync(int orderId, string status, string comment);


    }
}