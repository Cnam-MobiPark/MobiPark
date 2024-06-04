using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Models;
using MobiPark.Domain.Test.Repository;
using MobiPark.Domain.UseCases;

namespace MobiPark.Domain.Test;

public class UserTest
{
    private static User MakeUser()
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
        var hasher = new FakeHash();
        var useCase = new LoginUserUseCase(hasher, userRepository);

        // Act
        var user = useCase.Execute("toto", "tata");

        // Assert
        Assert.Equal(expectedUser, user);
    }

    [Fact]
    [Trait("User", "User not found")]
    public void User_WhenLoginUserButNotFound_ShouldThrowAnException()
    {
        // Arrange
        var userRepository = new FakeUserRepository([]);
        var hasher = new FakeHash();
        var useCase = new LoginUserUseCase(hasher, userRepository);

        // Act
        Action act = () => useCase.Execute("toto", "tata");

        // Assert
        Assert.Throws<NotFoundException>(act);
    }

    [Theory]
    [InlineData("toto", "password")]
    [InlineData("toto", "titi")]
    [Trait("User", "User login invalid credentials")]
    public void User_WhenLoginUserWithInvalidCredentials_ShouldThrowAnException(string username, string password)
    {
        // Arrange
        var user = MakeUser();
        var userRepository = new FakeUserRepository([user]);
        var hasher = new FakeHash();
        var useCase = new LoginUserUseCase(hasher, userRepository);

        // Act
        Action act = () => useCase.Execute(username, password);

        // Assert
        Assert.Throws<InvalidCredentialsException>(act);
    }

    [Theory]
    [InlineData("toto", "password")]
    [InlineData("toto", "titi")]
    [Trait("User", "User register")]
    public void User_WhenRegisterUserWithValidCredentials_ShouldWork(string username, string password)
    {
        // Arrange
        var userRepository = new FakeUserRepository([]);
        var hasher = new FakeHash();
        var useCase = new RegisterUserUseCase(hasher, userRepository);

        // Act
        var user = useCase.Execute(username, password);

        //Assert
        Assert.Equal(1, user.Id);
        Assert.Equal(user.Username, username);
        user.CheckPassword(hasher, password);
    }
}