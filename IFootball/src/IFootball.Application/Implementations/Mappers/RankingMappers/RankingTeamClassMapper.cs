using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Core;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.RankingMappers;

public static class RankingTeamClassMapper
{
    public static RankingTeamClassDto ToRankingTeamClassDto(this ScoreTeamClass scoreTeamClass)
    {
        return new RankingTeamClassDto
        {
            ClassName = scoreTeamClass.TeamClass.Class.Name,
            Score = scoreTeamClass.Score
        };
    }
}