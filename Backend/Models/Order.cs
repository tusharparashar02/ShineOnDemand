using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    public string? WasherId { get; set; }

    [ForeignKey("WasherId")]
    public ApplicationUser Washer { get; set; }

    [Required]
    public string CarNumber { get; set; }

    [ForeignKey("CarNumber")]
    public Car Car { get; set; } 

    [Required]
    public int? PackageId { get; set; }

    [Required]
    public string Address{ get; set; }

    public DateTime ScheduledDate { get; set; }

    public string? Status { get; set; } // PENDING, ACCEPTED, COMPLETED, CANCELLED

    public string? WasherComment { get; set; }
    public decimal? TotalAmount { get; set; }

    public ICollection<OrderAddOn>? OrderAddOns { get; set; }
}
