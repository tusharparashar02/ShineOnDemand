using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Payment
{
    public class PaymentReceiptDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string ReceiptImageUrl { get; set; }
    }
}
