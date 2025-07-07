using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Interface;
using Backend.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoCodesController : ControllerBase
    {
        private readonly IPromoCodeService _service;

        public PromoCodesController(IPromoCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromoCodeDTO>>> GetAll()
        {
            var promoCodes = await _service.GetAllAsync();
            return Ok(promoCodes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromoCodeDTO>> GetById(int id)
        {
            var promoCode = await _service.GetByIdAsync(id);
            if (promoCode == null)
            {
                return NotFound();
            }
            return Ok(promoCode);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PromoCodeDTO promoCodeDto)
        {
            await _service.AddAsync(promoCodeDto);
            return CreatedAtAction(
            nameof(GetById),
            new { id = promoCodeDto.Id },
            promoCodeDto
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PromoCodeDTO promoCodeDto)
        {
            if (id != promoCodeDto.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(promoCodeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}