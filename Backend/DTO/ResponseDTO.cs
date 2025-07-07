using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO
{
    public class ResponseDTO<T>
    {
        public bool Success {get; set;}
        public string Message {get; set;}
        public T Data {get; set;}
    }
}