using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.BusinessLayer.Interface;
using Backend.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderAddOnsController : ControllerBase
    {
        private readonly IOrderAddOnService _service;

        public OrderAddOnsController(IOrderAddOnService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderAddOnDTO>>> GetAll()
        {
            var addOns = await _service.GetAllAsync();
            return Ok(addOns);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderAddOnDTO>> GetById(int id)
        {
            var addOn = await _service.GetByIdAsync(id);
            if (addOn == null)
            {
                return NotFound();
            }
            return Ok(addOn);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderAddOnDTO orderAddOnDto)
        {
            await _service.AddAsync(orderAddOnDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = orderAddOnDto.AddOnId },
                orderAddOnDto
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OrderAddOnDTO orderAddOnDto)
        {
            if (id != orderAddOnDto.AddOnId)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(orderAddOnDto);
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
