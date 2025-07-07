using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Order
{
    public class PromoCodeDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercent { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime ValidTill { get; set; }
    }
}