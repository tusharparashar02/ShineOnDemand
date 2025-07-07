using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BusinessLayer.Interface;
using Backend.BusinessLayer.Services;
using Backend.DTO.Payment;
using Backend.Repository.Interface;
using Backend.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentReceiptsController : ControllerBase
    {
        private readonly IPaymentReceiptService _service;

        public PaymentReceiptsController(IPaymentReceiptService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentReceiptDTO>>> GetAll()
        {
            var paymentReceipts = await _service.GetAllAsync();
            return Ok(paymentReceipts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentReceiptDTO>> GetById(int id)
        {
            var paymentReceipt = await _service.GetByIdAsync(id);
            if (paymentReceipt == null)
            {
                return NotFound();
            }
            return Ok(paymentReceipt);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PaymentReceiptDTO paymentReceiptDto)
        {
            await _service.AddAsync(paymentReceiptDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = paymentReceiptDto.Id },
                paymentReceiptDto
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PaymentReceiptDTO paymentReceiptDto)
        {
            if (id != paymentReceiptDto.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(paymentReceiptDto);
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
