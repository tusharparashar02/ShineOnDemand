using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repository.Interface
{
    public interface IPaymentReceiptRepository
    {
        Task<IEnumerable<PaymentReceipt>> GetAllAsync();
        Task<PaymentReceipt> GetByIdAsync(int id);
        Task AddAsync(PaymentReceipt paymentReceipt);
        Task UpdateAsync(PaymentReceipt paymentReceipt);
        Task DeleteAsync(int id);
    }
}
