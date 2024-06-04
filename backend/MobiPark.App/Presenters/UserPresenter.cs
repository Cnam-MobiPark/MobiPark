using MobiPark.Domain.Models;

namespace MobiPark.App.Presenters;

public class UserPresenter
{
    public UserPresenter(User user)
    {
        ID = user.Id;
        Username = user.Username;
    }

    public int ID { get; }
    public string Username { get; }
}