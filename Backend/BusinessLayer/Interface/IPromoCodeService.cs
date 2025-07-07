using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.Order;

namespace Backend.BusinessLayer.Interface
{
    public interface IPromoCodeService
    {
        Task<IEnumerable<PromoCodeDTO>> GetAllAsync();
        Task<PromoCodeDTO> GetByIdAsync(int id);
        Task AddAsync(PromoCodeDTO promoCodeDto);
        Task UpdateAsync(PromoCodeDTO promoCodeDto);
        Task DeleteAsync(int id);
    }
}