namespace MobiPark.Domain.Exceptions;

public class AbstractBadDataException(string message) : ArgumentException(message);