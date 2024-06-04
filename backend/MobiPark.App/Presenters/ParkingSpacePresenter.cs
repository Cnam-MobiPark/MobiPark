using MobiPark.Domain.Models;

namespace MobiPark.App.Presenters;

public class ParkingSpacePresenter
{
    public ParkingSpacePresenter(ParkingSpace space)
    {
        Number = space.Number;
        Type = space.Size.ToString();
        Status = space.Status.ToString();
    }

    public int Number { get; }
    public string Type { get; }
    public string Status { get; }
}