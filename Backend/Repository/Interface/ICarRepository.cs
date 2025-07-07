using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repository.Interface
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByNumberAsync(string carNumber);
        Task<Car> AddCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<bool> DeleteCarAsync(string carNumber);

    }
}
