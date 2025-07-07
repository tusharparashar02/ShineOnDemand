using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Services
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsAsync()
        {
            return await _context.Ratings.ToListAsync();
        }

        public async Task<Rating> GetRatingByIdAsync(int id)
        {
            return await _context.Ratings.FindAsync(id);
        }

        public async Task AddRatingAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRatingAsync(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Rating>> GetRatingsByWasherIdAsync(string washerId)
        {
            return await _context.Ratings.Where(r => r.WasherId == washerId).ToListAsync();
        }
    }

}