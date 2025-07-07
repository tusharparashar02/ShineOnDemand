using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Order
{
    public class OrderAddOnDTO
    {
        public int AddOnId { get; set; }
        public string AddOnName { get; set; }
        public decimal AddOnPrice { get; set; }
    }
}
