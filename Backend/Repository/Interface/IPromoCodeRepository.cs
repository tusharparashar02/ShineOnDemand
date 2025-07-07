using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Interface
{
    public interface IPromoCodeRepository
    {
        Task<IEnumerable<PromoCode>> GetAllAsync();
        Task<PromoCode> GetByIdAsync(int id);
        Task AddAsync(PromoCode promoCode);
        Task UpdateAsync(PromoCode promoCode);
        Task DeleteAsync(int id);
    }
}