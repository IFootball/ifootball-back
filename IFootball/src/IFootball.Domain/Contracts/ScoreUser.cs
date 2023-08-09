using IFootball.Domain.Models;

namespace IFootball.Core;

public class ScoreUser
{
    public User User { get; set; }
    public int Score { get; set; }

    public ScoreUser(User user, int id)
    {
        User = user;
        Score = user.GetScore(id);
    }
}