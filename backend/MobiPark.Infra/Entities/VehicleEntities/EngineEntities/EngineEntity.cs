using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.Infra.Entities.VehicleEntities.EngineEntities;

public abstract class EngineEntity
{
    public int Id { get; set; }

    public abstract Engine ToDomainModel();
}