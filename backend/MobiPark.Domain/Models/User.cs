using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Models;

using UserId = int;

public class User
{
    public string Password;
    public UserId Id;
    public string Username;

    private User(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new NullUsernameException();

        Username = username;
    }

    public User(UserId userId, string username, string password) : this(username)
    {
        Id = userId;
        Password = password;
    }

    public User(string username, string clearTextPassword, IHash hash) : this(username)
    {
        if (string.IsNullOrEmpty(clearTextPassword))
            throw new NullPasswordException();

        Password = hash.Hash(clearTextPassword);
    }

    public void CheckPassword(IHash hash, string password)
    {
        if (!hash.Verify(password, Password)) throw new InvalidCredentialsException();
    }
}