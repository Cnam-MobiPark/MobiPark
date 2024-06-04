using MobiPark.Domain.Models;

namespace MobiPark.App.Presenters
{
    public class ParkingSpacePresenter
    {
        public int Number { get; private set; }
        public string Type { get; private set; }
        public string Status { get; private set; }

        public ParkingSpacePresenter(ParkingSpace space)
        {
            Number = space.Number;
            Type = space.Size.ToString();
            Status = space.Status.ToString();
        }
    }
}