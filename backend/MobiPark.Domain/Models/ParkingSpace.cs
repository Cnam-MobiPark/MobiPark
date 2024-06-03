using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Models;

using ParkingSpaceNumber = int ;

public enum ParkingSpaceStatus
{
    Available,
    Occupied
}

public class ParkingSpace
{
    public ParkingSpaceNumber Number { get; set; }
    public VehicleSize Size { get; set; }
    public ParkingSpaceStatus Status { get; set; }
    
    public ParkingSpace(
        ParkingSpaceNumber number,
        VehicleSize size,
        ParkingSpaceStatus status = ParkingSpaceStatus.Available
    )
    {
        Number = number;
        Size = size;
        Status = status;
    }
}