using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Infra.Entities.VehicleEntities.LicensePlateEntities;

    public abstract class LicensePlateEntity
    {
        public string Value { get; set; }

        public abstract AbstractLicensePlate ToDomainModel();
    }