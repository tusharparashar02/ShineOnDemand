using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Interface;
using Backend.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDTO>>> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllRatingsAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RatingDTO>> GetRatingById(int id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult> AddRating(RatingDTO ratingDto)
        {
            await _ratingService.AddRatingAsync(ratingDto);
            return CreatedAtAction(nameof(GetRatingById), new { id = ratingDto.Id }, ratingDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRating(int id, RatingDTO ratingDto)
        {
            if (id != ratingDto.Id)
            {
                return BadRequest();
            }
            await _ratingService.UpdateRatingAsync(ratingDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRating(int id)
        {
            await _ratingService.DeleteRatingAsync(id);
            return NoContent();
        }

        [HttpGet("washer/{washerId}")]
        public async Task<ActionResult<IEnumerable<RatingDTO>>> GetRatingsByWasherId(string washerId)
        {
            var ratings = await _ratingService.GetRatingsByWasherIdAsync(washerId);
            if (ratings == null || !ratings.Any())
            {
                return NotFound(new { message = "No ratings found for this washer." });
            }
            return Ok(ratings);
        }
    }

}