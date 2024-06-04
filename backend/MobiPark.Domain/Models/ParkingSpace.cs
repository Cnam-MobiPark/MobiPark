using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Models;

using ParkingSpaceNumber = int;

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
    public bool IsElectric { get; set; }

    public ParkingSpace(
        ParkingSpaceNumber number,
        VehicleSize size,
        bool isElectric,
        ParkingSpaceStatus status = ParkingSpaceStatus.Available
    )
    {
        Number = number;
        Size = size;
        IsElectric = isElectric;
        Status = status;
    }
}