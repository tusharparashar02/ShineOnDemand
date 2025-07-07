using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Repository.Interface;
using Backend.DTO.Car;
using AutoMapper;


namespace Backend.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarsAsync();
            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }

        public async Task<CarDTO> GetCarByNumberAsync(string carNumber)
        {
            var car = await _carRepository.GetCarByNumberAsync(carNumber);
            return car != null ? _mapper.Map<CarDTO>(car) : null;
        }

        public async Task<CarDTO> AddCarAsync(CarDTO carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            var newCar = await _carRepository.AddCarAsync(car);
            return _mapper.Map<CarDTO>(newCar);
        }

        public async Task<CarDTO> UpdateCarAsync(CarDTO carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            var updatedCar = await _carRepository.UpdateCarAsync(car);
            return _mapper.Map<CarDTO>(updatedCar);
        }

        public async Task<bool> DeleteCarAsync(string carNumber)
        {
            return await _carRepository.DeleteCarAsync(carNumber);
        }
    }

}