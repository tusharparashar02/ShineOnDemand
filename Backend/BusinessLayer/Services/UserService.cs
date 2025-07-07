using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Repository.Interface;
public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllWashersAsync()
    {
        return await _userRepository.GetAllWashersAsync();
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllCustomersAsync()
    {
        return await _userRepository.GetAllCustomersAsync();
    }
}