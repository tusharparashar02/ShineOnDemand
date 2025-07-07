using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.User
{
    public class WasherRequestDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Status { get; set; }
    }
}