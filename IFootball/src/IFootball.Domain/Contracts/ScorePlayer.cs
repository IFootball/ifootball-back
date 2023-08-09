using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts;

public class ScorePlayer
{
    public Player Player { get; private set; }
    public int Score { get; private set; }

    public ScorePlayer(Player player)
    {
        Player = player;
        Score = player.GetScore();
    }
}