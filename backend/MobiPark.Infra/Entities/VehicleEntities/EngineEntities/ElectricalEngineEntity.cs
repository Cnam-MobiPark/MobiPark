using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.Infra.Entities.VehicleEntities.EngineEntities;

public class ElectricalEngineEntity : EngineEntity
{
    public int BatteryCapacity { get; set; }
    public int CurrentBatteryCapacity { get; set; }

    public override Engine ToDomainModel()
    {
        return new ElectricalEngine(BatteryCapacity, CurrentBatteryCapacity)
        {
            Id = Id
        };
    }

    public ElectricalEngineEntity() { }

    public ElectricalEngineEntity(ElectricalEngine engine)
    {
        Id = engine.Id;
        BatteryCapacity = engine.BatteryCapacity;
        CurrentBatteryCapacity = engine.CurrentBatteryCapacity;
    }
}