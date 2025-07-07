using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Interface;
using Backend.DTO.User;
using Backend.Repository.Interface;

namespace Backend.BusinessLayer.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RatingDTO>> GetAllRatingsAsync()
        {
            var ratings = await _ratingRepository.GetAllRatingsAsync();
            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }

        public async Task<RatingDTO> GetRatingByIdAsync(int id)
        {
            var rating = await _ratingRepository.GetRatingByIdAsync(id);
            return _mapper.Map<RatingDTO>(rating);
        }

        public async Task AddRatingAsync(RatingDTO ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            await _ratingRepository.AddRatingAsync(rating);
        }

        public async Task UpdateRatingAsync(RatingDTO ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            await _ratingRepository.UpdateRatingAsync(rating);
        }

        public async Task DeleteRatingAsync(int id)
        {
            await _ratingRepository.DeleteRatingAsync(id);
        }
        public async Task<IEnumerable<RatingDTO>> GetRatingsByWasherIdAsync(string washerId)
        {
            var ratings = await _ratingRepository.GetRatingsByWasherIdAsync(washerId);
            return _mapper.Map<IEnumerable<RatingDTO>>(ratings);
        }
    }

}