namespace MobiPark.Domain.Exceptions;

public class InvalidLicensePlateException : ArgumentException
{
    public InvalidLicensePlateException(string value) : base("Invalid license plate: " + value)
    {
    }
}