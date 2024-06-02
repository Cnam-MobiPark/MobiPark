using MobiPark.Domain.Models.Vehicle;
using MobiPark.Infra.Entities.VehicleEntities;

namespace MobiPark.Infra.Entities;

public class CarEntity : VehicleEntity
{
    public CarEntity() { }

    public CarEntity(Car car) : base(car) { }

    public override Vehicle ToDomainModel()
    {
        return new Car(Maker, LicensePlate.ToDomainModel(), Engine.ToDomainModel());
    }
}