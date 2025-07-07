using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.User;

namespace Backend.BusinessLayer.Interface
{
    public interface IRatingService
    {

        Task<IEnumerable<RatingDTO>> GetAllRatingsAsync();
        Task<RatingDTO> GetRatingByIdAsync(int id);
        Task AddRatingAsync(RatingDTO ratingDto);
        Task UpdateRatingAsync(RatingDTO ratingDto);
        Task DeleteRatingAsync(int id);
        Task<IEnumerable<RatingDTO>> GetRatingsByWasherIdAsync(string washerId);

    }
}