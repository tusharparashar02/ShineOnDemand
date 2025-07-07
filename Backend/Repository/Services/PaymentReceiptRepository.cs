using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Services
{
    public class PaymentReceiptRepository : IPaymentReceiptRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentReceiptRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentReceipt>> GetAllAsync()
        {
            return await _context.PaymentReceipts.ToListAsync();
        }

        public async Task<PaymentReceipt> GetByIdAsync(int id)
        {
            return await _context.PaymentReceipts.FindAsync(id);
        }

        public async Task AddAsync(PaymentReceipt paymentReceipt)
        {
            await _context.PaymentReceipts.AddAsync(paymentReceipt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PaymentReceipt paymentReceipt)
        {
            _context.PaymentReceipts.Update(paymentReceipt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paymentReceipt = await _context.PaymentReceipts.FindAsync(id);
            if (paymentReceipt != null)
            {
                _context.PaymentReceipts.Remove(paymentReceipt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
