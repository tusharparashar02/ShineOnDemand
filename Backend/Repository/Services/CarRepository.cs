using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Context;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByNumberAsync(string carNumber)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.CarNumber == carNumber);
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<bool> DeleteCarAsync(string carNumber)
        {
            var relatedOrders = _context.Orders.Where(o => o.CarNumber == carNumber);
            _context.Orders.RemoveRange(relatedOrders);

            var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarNumber == carNumber);
            if (car == null) return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
