using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Test.Repository;

public class FakeClock(DateTime _dateTime) : IClock
{
    public DateTime Now()
    {
        return _dateTime;
    }
}