namespace MobiPark.Domain.Exceptions;

public class InvalidBatteryException(string message) : AbstractBadDataException(message);