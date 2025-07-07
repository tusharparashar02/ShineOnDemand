using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Interface
{
    public interface IRatingRepository
    {

        Task<IEnumerable<Rating>> GetAllRatingsAsync();
        Task<Rating> GetRatingByIdAsync(int id);
        Task AddRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(int id);
        Task<IEnumerable<Rating>> GetRatingsByWasherIdAsync(string washerId);

    }
}