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
    public int Size { get; set; }
    public ParkingSpaceStatus Status { get; set; }
    
    public ParkingSpace(
        ParkingSpaceNumber number,
        int size,
        ParkingSpaceStatus status = ParkingSpaceStatus.Available
    )
    {
        Number = number;
        Size = size;
        Status = status;
    }
}