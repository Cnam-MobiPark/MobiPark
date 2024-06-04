using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Models;

using UserId = int;
public class User
{
    public UserId Id;
    public string Username = null!;
    private string _password = null!;

    public User(UserId userId, string username, string password)
    {
        Id = userId;
        Username = username;
        _password = password;
    }

    public User(string username, string clearTextPassword, IHash hash)
    {
        Username = username;
        _password = hash.Hash(clearTextPassword);
    }
    
    public void CheckPassword(IHash hash, string password)
    {
        if (!hash.Verify(password, _password)) throw new InvalidCredentialsException();
    }
}