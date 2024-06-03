using MobiPark.Domain.Interfaces;

namespace MobiPark.Infra;

public class Clock : IClock
{
    public DateTime Now()
    {
        return DateTime.Now;
    }
}