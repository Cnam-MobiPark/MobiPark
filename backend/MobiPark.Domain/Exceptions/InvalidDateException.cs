namespace MobiPark.Domain.Exceptions;

public class InvalidDateException(string message) : ArgumentException("Invalid date: " + message);