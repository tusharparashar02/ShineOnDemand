using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Order
{
    public class UpdateOrderStatusDTO
    {
        public string Status { get; set; }
        public string Comment { get; set; } // ✅ New field for washer's comment
    }

}