using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Models;

using UserId = int;
public class User(UserId userId, string username, string password)
{
    public UserId Id = userId;
    public string Username = username;
    private string _password = password;
    
    public void CheckPassword(IHash hash, string password)
    {
        if (!hash.Verify(password, _password))
        {
            throw new InvalidCredentialsException();
        }
    }
}