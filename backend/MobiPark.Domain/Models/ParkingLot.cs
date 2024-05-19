namespace MobiPark.Domain.Models
{
    public class ParkingLot
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int TotalCapacity { get; set; }
        public int AvailableSpaces { get; set; }
        public List<ParkingSpace> Spaces { get; set; }
    }
}