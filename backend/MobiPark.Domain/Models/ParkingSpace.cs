namespace MobiPark.Dom.Models
{
    public class ParkingSpace
    {
        public int Number { get; set; }
        public required string Type { get; set; }
        public required string Status { get; set; }
        public object? Vehicle { get; set; }
    }
}