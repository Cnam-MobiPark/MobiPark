namespace MobiPark.Domain.Exceptions;

public class UsernameAlreadyExistException(string username) : ConflictException($"username {username} already exists");