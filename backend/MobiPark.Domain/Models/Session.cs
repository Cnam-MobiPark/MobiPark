namespace MobiPark.Domain.Models;

public class Session
{
    public User User;
    
    public Session(User user)
    {
        User = user;
    }
}