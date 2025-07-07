using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.BusinessLayer.Interface;
using Backend.DTO.Order;
using Backend.Repository.Interface;

namespace Backend.BusinessLayer.Services
{
    public class OrderAddOnService : IOrderAddOnService
    {
        private readonly IOrderAddOnRepository _repository;
        private readonly IMapper _mapper;

        public OrderAddOnService(IOrderAddOnRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderAddOnDTO>> GetAllAsync()
        {
            var addOns = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderAddOnDTO>>(addOns);
        }

        public async Task<OrderAddOnDTO> GetByIdAsync(int id)
        {
            var addOn = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrderAddOnDTO>(addOn);
        }

        public async Task AddAsync(OrderAddOnDTO orderAddOnDto)
        {
            var addOn = _mapper.Map<AddOn>(orderAddOnDto);
            await _repository.AddAsync(addOn);
        }

        public async Task UpdateAsync(OrderAddOnDTO orderAddOnDto)
        {
            var addOn = _mapper.Map<AddOn>(orderAddOnDto);
            await _repository.UpdateAsync(addOn);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
