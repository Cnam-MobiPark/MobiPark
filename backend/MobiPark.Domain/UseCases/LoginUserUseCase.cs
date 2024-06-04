using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.UseCases;

public class LoginUserUseCase(IHash hash, IUserRepository userRepository)
{
    public User Execute(string username, string password)
    {
        var user = userRepository.FindByUsername(username);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        
        user.CheckPassword(hash, password);

        return user;
    }
}