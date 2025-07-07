using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PaymentReceipt
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal AmountPaid { get; set; }

    public string ReceiptImageUrl { get; set; }
}
