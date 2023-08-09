using IFootball.Domain.Models;

namespace IFootball.Core;

public class ScoreTeamClass
{
    public TeamClass TeamClass { get; set; }
    public int Score { get; set; }

    public ScoreTeamClass(TeamClass teamClass)
    {
        TeamClass = teamClass;
        Score = teamClass.GetScore();
    }
}