using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DTO.Car;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN, Customer")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;
        private readonly ILogger<CarController> _logger;

        public CarController(CarService carService, ILogger<CarController> logger)
        {
            _carService = carService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetAllCars()
        {
            _logger.LogInformation("Fetching all cars...");
            var cars = (await _carService.GetAllCarsAsync()).ToList();

            return cars.Any() ? Ok(cars) : NoContent();
        }


        [HttpGet("{carNumber}")]
        public async Task<ActionResult<CarDTO>> GetCarByNumber(string carNumber)
        {
            _logger.LogInformation($"Fetching car with number: {carNumber}");
            var car = await _carService.GetCarByNumberAsync(carNumber);
            return car != null ? Ok(car) : NotFound(new { message = "Car not found" });
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> AddCar([FromBody] CarDTO carDto)
        {
            if (carDto == null || string.IsNullOrEmpty(carDto.UserId))
                return BadRequest(new { message = "Invalid car data or missing UserId" });

            _logger.LogInformation($"Adding car for user: {carDto.UserId}");
            var newCar = await _carService.AddCarAsync(carDto);
            return CreatedAtAction("GetCarByNumber", new { carNumber = newCar.CarNumber }, newCar);
        }

        [HttpPut]
        public async Task<ActionResult<CarDTO>> UpdateCar([FromBody] CarDTO carDto)
        {
            if (carDto == null || string.IsNullOrEmpty(carDto.UserId))
                return BadRequest(new { message = "Invalid car data or missing UserId" });

            _logger.LogInformation($"Updating car: {carDto.CarNumber}");
            var updatedCar = await _carService.UpdateCarAsync(carDto);
            return Ok(updatedCar);
        }

        [HttpDelete("{carNumber}")]
        public async Task<ActionResult> DeleteCar(string carNumber)
        {
            _logger.LogInformation($"Deleting car with number: {carNumber}");
            var result = await _carService.DeleteCarAsync(carNumber);
            return result ? NoContent() : NotFound(new { message = "Car not found" });
        }
    }

}