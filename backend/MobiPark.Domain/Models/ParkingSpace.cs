namespace MobiPark.Domain.Models;

using ParkingSpaceNumber = int ;
    
public class ParkingSpace
{
    public ParkingSpaceNumber Number { get; set; }
    public required string Type { get; set; }
    public required string Status { get; set; }
    public Vehicle.Vehicle? Vehicle { get; set; }
}