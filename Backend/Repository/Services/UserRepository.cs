using Microsoft.AspNetCore.Identity;
using Backend.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Repository.Interface;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllWashersAsync()
    {
        var users = await _context.Users.ToListAsync();
        var washers = new List<ApplicationUser>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Washer"))
            {
                user.Roles = roles.ToList();
                washers.Add(user);
            }
        }

        return washers;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllCustomersAsync()
    {
        var users = await _context.Users.ToListAsync();
        var customers = new List<ApplicationUser>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Customer"))
            {
                user.Roles = roles.ToList();
                customers.Add(user);
            }
        }

        return customers;
    }
}