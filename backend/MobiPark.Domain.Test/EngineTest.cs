using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.Domain.Test;

public class EngineTest
{
    [Fact]
    [Trait("Engine", "Creating Engines")]
    public void CreateElectricalEngine_ShouldCreateElectricalEngine()
    {
        // Arrange
        var batteryCapacity = 100;
        var currentBatteryCapacity = 50;

        // Act
        var engine = new ElectricalEngine(batteryCapacity, currentBatteryCapacity);

        // Assert
        Assert.NotNull(engine);
        Assert.IsType<ElectricalEngine>(engine);
        Assert.Equal(batteryCapacity, engine.BatteryCapacity);
        Assert.Equal(currentBatteryCapacity, engine.CurrentBatteryCapacity);
        Assert.Equal(50, engine.BatteryLevel);
    }
    
    [Fact]
    [Trait("Engine", "Creating Engines")]
    public void CreateElectricalEngine_WithNegativeBatteryCapacity_ShouldThrowInvalidBatteryException()
    {
        // Arrange
        var batteryCapacity = -100;
        var currentBatteryCapacity = 50;

        // Act
        var exception = Assert.Throws<InvalidBatteryException>(() => new ElectricalEngine(batteryCapacity, currentBatteryCapacity));

        // Assert
        Assert.Equal("Battery capacity : -100 cannot be negative or zero.", exception.Message);
    }
    
    [Fact]
    [Trait("Engine", "Creating Engines")]
    public void CreateElectricalEngine_WithNegativeCurrentBatteryCapacity_ShouldThrowInvalidBatteryException()
    {
        // Arrange
        var batteryCapacity = 100;
        var currentBatteryCapacity = -50;

        // Act
        var exception = Assert.Throws<InvalidBatteryException>(() => new ElectricalEngine(batteryCapacity, currentBatteryCapacity));

        // Assert
        Assert.Equal("Current battery capacity : -50 cannot be negative.", exception.Message);
    }
    
    [Fact]
    [Trait("Engine", "Creating Engines")]
    public void CreateElectricalEngine_WithCurrentBatteryCapacityGreaterThanBatteryCapacity_ShouldThrowInvalidBatteryException()
    {
        // Arrange
        var batteryCapacity = 100;
        var currentBatteryCapacity = 150;

        // Act
        var exception = Assert.Throws<InvalidBatteryException>(() => new ElectricalEngine(batteryCapacity, currentBatteryCapacity));

        // Assert
        Assert.Equal("Current battery capacity : 150 cannot be greater than battery capacity : 100", exception.Message);
    }
}