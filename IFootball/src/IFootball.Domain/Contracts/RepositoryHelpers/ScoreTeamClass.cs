using IFootball.Domain.Models;

namespace IFootball.Core;

public class ScoreTeamClass
{
    public TeamClass TeamClass { get; private set; }
    public int Score { get; private set; }

    public ScoreTeamClass(TeamClass teamClass)
    {
        TeamClass = teamClass;
        Score = teamClass.GetScore();
    }
}