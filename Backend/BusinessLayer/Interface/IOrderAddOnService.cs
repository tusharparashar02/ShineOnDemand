using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DTO.Order;

namespace Backend.BusinessLayer.Interface
{
    public interface IOrderAddOnService
    {
        Task<IEnumerable<OrderAddOnDTO>> GetAllAsync();
        Task<OrderAddOnDTO> GetByIdAsync(int id);
        Task AddAsync(OrderAddOnDTO orderAddOnDto);
        Task UpdateAsync(OrderAddOnDTO orderAddOnDto);
        Task DeleteAsync(int id);
    }
}
