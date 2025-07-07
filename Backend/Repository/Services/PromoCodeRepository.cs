using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Services
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly ApplicationDbContext _context;

        public PromoCodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PromoCode>> GetAllAsync()
        {
            return await _context.PromoCodes.ToListAsync();
        }

        public async Task<PromoCode> GetByIdAsync(int id)
        {
            return await _context.PromoCodes.FindAsync(id);
        }

        public async Task AddAsync(PromoCode promoCode)
        {
            _context.PromoCodes.Add(promoCode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PromoCode promoCode)
        {
            _context.PromoCodes.Update(promoCode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var promoCode = await _context.PromoCodes.FindAsync(id);
            if (promoCode != null)
            {
                _context.PromoCodes.Remove(promoCode);
                await _context.SaveChangesAsync();
            }
        }
    }

}