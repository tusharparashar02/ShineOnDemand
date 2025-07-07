using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Services
{
    public class OrderAddOnRepository : IOrderAddOnRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderAddOnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddOn>> GetAllAsync()
        {
            return await _context.AddOns.ToListAsync();
        }

        public async Task<AddOn> GetByIdAsync(int id)
        {
            return await _context.AddOns.FindAsync(id);
        }

        public async Task AddAsync(AddOn addOn)
        {
            _context.AddOns.Add(addOn);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AddOn addOn)
        {
            _context.AddOns.Update(addOn);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var addOn = await _context.AddOns.FindAsync(id);
            if (addOn != null)
            {
                _context.AddOns.Remove(addOn);
                await _context.SaveChangesAsync();
            }
        }
    }
}