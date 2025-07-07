using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Order
{
    public class AssignOrderDTO
    {
            [Required]
            public int OrderId { get; set; }

            [Required]
            public string WasherId { get; set; }
        }
}