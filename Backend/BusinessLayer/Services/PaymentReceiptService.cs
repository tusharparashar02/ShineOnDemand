using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Interface;
using Backend.Context;
using Backend.DTO.Payment;
using Backend.Repository.Interface;
using Backend.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.BusinessLayer.Services
{
    public class PaymentReceiptService : IPaymentReceiptService
    {
        private readonly IPaymentReceiptRepository _repository;
        private readonly IMapper _mapper;

        public PaymentReceiptService(IPaymentReceiptRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentReceiptDTO>> GetAllAsync()
        {
            var paymentReceipts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentReceiptDTO>>(paymentReceipts);
        }

        public async Task<PaymentReceiptDTO> GetByIdAsync(int id)
        {
            var paymentReceipt = await _repository.GetByIdAsync(id);
            return _mapper.Map<PaymentReceiptDTO>(paymentReceipt);
        }

        public async Task AddAsync(PaymentReceiptDTO paymentReceiptDto)
        {
            var paymentReceipt = _mapper.Map<PaymentReceipt>(paymentReceiptDto);
            await _repository.AddAsync(paymentReceipt);
        }

        public async Task UpdateAsync(PaymentReceiptDTO paymentReceiptDto)
        {
            var paymentReceipt = _mapper.Map<PaymentReceipt>(paymentReceiptDto);
            await _repository.UpdateAsync(paymentReceipt);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
