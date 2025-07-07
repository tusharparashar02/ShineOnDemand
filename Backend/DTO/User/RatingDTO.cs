using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.User
{
    public class RatingDTO
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string WasherId { get; set; }
        public int RatingValue { get; set; }

    }
}