namespace MobiPark.Domain.Exceptions;

public class VehicleCannotParkException : Exception
{
    public VehicleCannotParkException(string message) : base(message)
    {
    }
}