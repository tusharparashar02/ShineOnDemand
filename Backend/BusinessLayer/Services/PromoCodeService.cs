using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Interface;
using Backend.DTO.Order;
using Backend.Repository.Interface;

namespace Backend.BusinessLayer.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IPromoCodeRepository _repository;
        private readonly IMapper _mapper;

        public PromoCodeService(IPromoCodeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PromoCodeDTO>> GetAllAsync()
        {
            var promoCodes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PromoCodeDTO>>(promoCodes);
        }

        public async Task<PromoCodeDTO> GetByIdAsync(int id)
        {
            var promoCode = await _repository.GetByIdAsync(id);
            return _mapper.Map<PromoCodeDTO>(promoCode);
        }

        public async Task AddAsync(PromoCodeDTO promoCodeDto)
        {
            var promoCode = _mapper.Map<PromoCode>(promoCodeDto);
            await _repository.AddAsync(promoCode);
        }

        public async Task UpdateAsync(PromoCodeDTO promoCodeDto)
        {
            var promoCode = _mapper.Map<PromoCode>(promoCodeDto);
            await _repository.UpdateAsync(promoCode);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}