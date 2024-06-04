using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Models;

using UserId = int;
public class User(UserId userId, string username, string password)
{
    public UserId Id = userId;
    public string Username = username;
    private string _password = password;

    public static Session Login(string username, string password, IHash hasher, IUserRepository userRepository)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new InvalidCredentialsException();
        }

        var user = userRepository.FindUserByUsername(username);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        if (!hasher.Verify(password, user._password))
        {
            throw new InvalidCredentialsException();
        }

        return new Session(user);
    }
}