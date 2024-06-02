using MobiPark.Domain.Models.Vehicle;
using MobiPark.Infra.Entities.VehicleEntities;

namespace MobiPark.Infra.Entities;

public class MotorcycleEntity : VehicleEntity
{
    public MotorcycleEntity() { }

    public MotorcycleEntity(Motorcycle motorcycle) : base(motorcycle) { }

    public override Vehicle ToDomainModel()
    {
        return new Motorcycle(Maker, LicensePlate.ToDomainModel(), Engine.ToDomainModel());
    }
}