using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.Payment;

namespace Backend.BusinessLayer.Interface
{
    public interface IPaymentReceiptService
    {
        Task<IEnumerable<PaymentReceiptDTO>> GetAllAsync();

        Task<PaymentReceiptDTO> GetByIdAsync(int id);

        Task AddAsync(PaymentReceiptDTO paymentReceiptDto);

        Task UpdateAsync(PaymentReceiptDTO paymentReceiptDto);

        Task DeleteAsync(int id);
    }
}
