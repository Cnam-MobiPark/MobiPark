using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.UseCases;

public class RegisterUserUseCase(IHash hash, IUserRepository userRepository)
{
    public User Execute(string username, string clearTextPassword)
    {
        var existingUser = userRepository.FindByUsername(username);
        if (existingUser != null)
            throw new UsernameAlreadyExistException(username);

        var user = new User(username, clearTextPassword, hash);
        var createdUser = userRepository.Save(user);

        return createdUser;
    }
}