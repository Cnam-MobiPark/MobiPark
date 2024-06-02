using MobiPark.Domain.Models.Vehicle;

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