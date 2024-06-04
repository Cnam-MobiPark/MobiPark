namespace MobiPark.Domain.Exceptions;

public class InvalidDateException(string message) : AbstractBadDataException("Invalid date: " + message);