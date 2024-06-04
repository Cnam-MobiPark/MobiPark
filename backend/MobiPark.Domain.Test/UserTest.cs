using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Models;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class UserTest
{
    private User MakeUser()
    {
        return new User(1, "toto", "tata");
    }
    
    [Fact]
    [Trait("User", "User login")]
    public void User_WhenLoginUser_ShouldReturnSession()
    {
        // Arrange
        var expectedUser = MakeUser();
        var userRepository = new FakeUserRepository([expectedUser]);

        // Act
        var session = User.Login("toto", "tata", new FakeHash(), userRepository);

        // Assert
        Assert.Equal(expectedUser, session.User);
    }
    
    [Fact]
    [Trait("User", "User login empty credentials")]
    public async void User_WhenLoginUserWithEmptyCredentials_ShouldThrowAnException()
    {
        // Arrange
        var user = MakeUser();
        var userRepository = new FakeUserRepository([user]);

        // Act
        Action act = () => User.Login("", "", new FakeHash(), userRepository);

        // Assert
        Assert.Throws<InvalidCredentialsException>(act);
    }
}