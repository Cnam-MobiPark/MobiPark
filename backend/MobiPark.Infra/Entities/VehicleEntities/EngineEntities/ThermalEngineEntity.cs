using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.Infra.Entities.VehicleEntities.EngineEntities;

public class ThermalEngineEntity : EngineEntity
{
    public override Engine ToDomainModel()
    {
        return new ThermalEngine
        {
            Id = Id
        };
    }

    public ThermalEngineEntity() { }

    public ThermalEngineEntity(ThermalEngine engine)
    {
        Id = engine.Id;
    }
}