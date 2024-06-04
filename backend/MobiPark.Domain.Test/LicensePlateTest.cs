using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Test;

public class LicensePlateTest
{
    
    [Fact]
    [Trait("LicencePlate", "Creating License Plates")]
    public void CreatingALicensePlateWithNullValue_ShouldThrowException()
    {
        // Arrange
        var nullLicensePlate = (string)null;

        // Act
        Action act = () => new FrLicensePlate(nullLicensePlate);
        
        // Assert
        Assert.Throws<InvalidLicensePlateException>(act);
        
    }
    
    [Fact]
    [Trait("LicencePlate", "Creating License Plates")]
    public void CreatingALicensePlateWithInvalidValue_ShouldThrowExceptionforFr()
    {
        // Arrange
        var maker = "Toyota";
        var invalidLicensePlate = "AB-123-CD-123";

        // Act
        Action act = () => new FrLicensePlate(invalidLicensePlate);

        // Assert
        Assert.Throws<InvalidLicensePlateException>(act);
    }
    
    [Fact]
    [Trait("LicencePlate", "Creating License Plates")]
    public void CreatingALicensePlateWithGoodValue_ShouldWorkforFr()
    {
        // Arrange
        var maker = "Toyota";
        var licensePlate = "AB-123-CD";

        // Act
        Action act = () => new FrLicensePlate(licensePlate);

        // Assert
        Assert.NotNull(act);
    }
    
    [Fact]
    [Trait("LicencePlate", "Creating License Plates")]
    public void CreatingALicensePlateWithInvalidValue_ShouldThrowExceptionforDe()
    {
        // Arrange
        var maker = "Toyota";
        var invalidLicensePlate = "AB-123-CD";
        
        // Act
        Action act = () => new DeLicensePlate(invalidLicensePlate);
        
        // Assert
        Assert.Throws<InvalidLicensePlateException>(act);
    }
    
    [Fact]
    [Trait("LicencePlate", "Creating License Plates")]
    public void CreatingALicensePlateWithGoodValue_ShouldWorkforDe()
    {
        // Arrange
        var maker = "Toyota";
        var licensePlate = "A X 1234";

        // Act
        Action act = () => new DeLicensePlate(licensePlate);

        // Assert
        Assert.NotNull(act);
    }
}