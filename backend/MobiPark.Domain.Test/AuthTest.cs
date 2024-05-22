namespace MobiPark.Domain.Test;

public class AuthTest
{
    [Fact]
    [Trait("Category", "Auth")]
    public void AuthService_Should_Authenticate_A_User()
    {
        // Arrange
        var user = new User { Id = 1, Username = "admin", Password = "admin" };
        var userRepository = new UserRepository(new User[] 
        {
            user
        });
        var authService = new AuthService(userRepository);

        // Act
        var authenticatedUser = authService.Authenticate(user.Username, user.Password);

        // Assert
        Assert.Equal(user, authenticatedUser);
    }
    
}