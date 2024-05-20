namespace MobiPark.Domain.Models
{
    public class ParkingSpace
    {
        public int Number { get; set; }
        public required string Type { get; set; }
        public required string Status { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}