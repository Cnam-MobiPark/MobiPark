using System.Text.Json.Serialization;

namespace MobiPark.App.DTO
{
    public class CreateVehicleDTO
    {
        public string Type { get; private set; }
        public string Maker { get; private set; }
        public CreateLicensePlateDTO LicensePlate { get; private set; }
        public CreateEngineDTO Engine { get; private set; }

        [JsonConstructor]
        public CreateVehicleDTO(string type, string maker, CreateLicensePlateDTO licensePlate, CreateEngineDTO engine)
        {
            Type = type;
            Maker = maker;
            LicensePlate = licensePlate;
            Engine = engine;
        }
    }
}