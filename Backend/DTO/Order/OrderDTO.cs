using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.User;

namespace Backend.DTO.Order
{
    public class OrderDTO
    {
        [Required]
        public string UserId { get; set; }



        [Required]
        public string CarNumber { get; set; }
        public int? PackageId { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }
        public decimal? TotalAmount { get; set; }

        public ICollection<OrderAddOnDTO> OrderAddOns { get; set; }
    }
}
