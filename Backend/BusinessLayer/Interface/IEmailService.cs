using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.BusinessLayer.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string body, string subject);
    }
}