namespace MobiPark.Domain.Exceptions;

public class InvalidBatteryException : System.ArgumentException
{
    public InvalidBatteryException(string message) : base(message)
    {
    }
}