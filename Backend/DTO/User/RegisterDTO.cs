using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.User
{
    public class RegisterDTO
    {
        public string Email {get; set;}
        public string Name {get; set;}
        public string Password{ get; set;}
        public string Role {get; set;}
    }
}