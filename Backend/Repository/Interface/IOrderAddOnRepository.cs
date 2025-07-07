using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Interface
{
    public interface IOrderAddOnRepository
    {
        Task<IEnumerable<AddOn>> GetAllAsync();
        Task<AddOn> GetByIdAsync(int id);
        Task AddAsync(AddOn addOn);
        Task UpdateAsync(AddOn addOn);
        Task DeleteAsync(int id);
    }
}
