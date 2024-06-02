using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Infra.Entities.VehicleEntities.LicensePlateEntities;

public class DeLicensePlateEntity : LicensePlateEntity
{
    public DeLicensePlateEntity() { }

    public DeLicensePlateEntity(DeLicensePlate licensePlate)
    {
        Value = licensePlate.Value;
    }

    public override AbstractLicensePlate ToDomainModel()
    {
        return new DeLicensePlate(Value);
    }
}