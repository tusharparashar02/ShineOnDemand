using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Car
{
    public class CarDTO
    {
        public string UserId { get; set; }
        public string Model { get; set; }
        public string CarNumber { get; set; }
        public int Year { get; set; }
        public bool IsActive { get; set; }
    }
}
