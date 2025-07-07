using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Services
{
    public class AssignOrderRepository : IAssignOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.User).Include(o => o.Washer).Include(o => o.Car).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.User).Include(o => o.Washer).Include(o => o.Car).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var washerExists = await _context.Users.AnyAsync(u => u.Id == order.WasherId);
            if (!washerExists)
            {
                throw new Exception("Invalid Washer ID: No washer found.");
            }

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }


}