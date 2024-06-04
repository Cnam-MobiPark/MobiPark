namespace MobiPark.Domain.Exceptions;

public class NullPasswordException : ArgumentNullException
{
    public NullPasswordException() : base("password")
    {
    }
}