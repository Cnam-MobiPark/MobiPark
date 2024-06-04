namespace MobiPark.Domain.Exceptions;

public class NullUsernameException : ArgumentNullException
{
    public NullUsernameException() : base("username") { }
}