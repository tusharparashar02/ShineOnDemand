using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Services
{
    public class WasherOrderRepository : IWasherOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public WasherOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByWasherIdAsync(string washerId)
        {
            return await _context.Orders.Where(o => o.WasherId == washerId).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> UpdateOrderStatusAsync(int orderId, string status, string comment)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return null;

            order.Status = status;
            order.WasherComment = comment; // ✅ Store the washer's comment

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }

    }

}