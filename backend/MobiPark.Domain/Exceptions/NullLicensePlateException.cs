namespace MobiPark.Domain.Exceptions;

public class NullLicensePlateException : ArgumentNullException
{
    public NullLicensePlateException() : base("Value cannot be null or empty.")
    {
    }
}