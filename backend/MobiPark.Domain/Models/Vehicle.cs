namespace MobiPark.Domain.Models
{
    public class Vehicle
    {
        public enum VehicleType
        {
            Car,
            Motorcycle
        }
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string Maker { get; set; }
        public string LicensePlate { get; set; }
    }
}