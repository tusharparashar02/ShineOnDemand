using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllWashersAsync();
        Task<IEnumerable<ApplicationUser>> GetAllCustomersAsync();
    }
}