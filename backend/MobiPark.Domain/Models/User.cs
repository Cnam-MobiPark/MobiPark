using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Models;

using UserId = int;

public class User
{
    private readonly string _password = null!;
    public UserId Id;
    public string Username = null!;

    private User(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new NullUsernameException();

        Username = username;
    }

    public User(UserId userId, string username, string password) : this(username)
    {
        Id = userId;
        _password = password;
    }

    public User(string username, string clearTextPassword, IHash hash) : this(username)
    {
        if (string.IsNullOrEmpty(clearTextPassword))
            throw new NullPasswordException();

        _password = hash.Hash(clearTextPassword);
    }

    public void CheckPassword(IHash hash, string password)
    {
        if (!hash.Verify(password, _password)) throw new InvalidCredentialsException();
    }
}