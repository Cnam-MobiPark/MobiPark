namespace MobiPark.Domain.Exceptions;

public class UsernameAlreadyExistException : Exception
{
    public UsernameAlreadyExistException(string username) : base($"username {username} already exists") { }
}