using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.Domain.Test;

public class EngineTest
{
    [Fact]
    [Trait("Category", "Creating Engines")]
    public void CreateThermalEngine_ShouldCreateThermalEngine()
    {
        // Act
        var engine = new ThermalEngine();

        // Assert
        Assert.NotNull(engine);
        Assert.IsType<ThermalEngine>(engine);
    }
}