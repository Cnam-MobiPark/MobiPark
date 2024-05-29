using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.Domain.Test;

public class EngineTest
{
    [Fact]
    [Trait("Category", "Creating Engines")]
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
        Assert.Equal(batteryCapacity, engine.batteryCapacity);
        Assert.Equal(currentBatteryCapacity, engine.currentBatteryCapacity);
        Assert.Equal(50, engine.batteryLevel);
    }
}