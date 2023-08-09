using IFootball.Domain.Models;

namespace IFootball.Core;

public class ScorePlayer
{
    public Player Player { get; set; }
    public int Score { get; set; }

    public ScorePlayer(Player player)
    {
        Player = player;
        Score = player.GetScore();
    }
}