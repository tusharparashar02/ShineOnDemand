using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public IList<string> Roles { get; set; } = new List<string>();

    public ICollection<Car> Cars { get; set; } = new List<Car>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
