using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.RankingMappers;

public static class RankingTeamClassMapper
{
    public static RankingTeamClassDto ToRankingTeamClassDto(this TeamClass teamClass)
    {
        return new RankingTeamClassDto
        {
            ClassName = teamClass.Class.Name,
            Score = teamClass.GetScore()
        };
    }
}