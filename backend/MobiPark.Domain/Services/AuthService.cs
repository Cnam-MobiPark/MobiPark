using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Services;

public class AuthService(IUserRepository userRepository)
{
    private IUserRepository _userRepository = userRepository;
    
    public User Authenticate(string username, string password)
    {
        var user = _userRepository.FindUserByUsername(username);

        return user;
    }
}