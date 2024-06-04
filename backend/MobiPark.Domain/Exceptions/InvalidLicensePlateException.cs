namespace MobiPark.Domain.Exceptions;

public class InvalidLicensePlateException(string value) : AbstractBadDataException("Invalid license plate: " + value);