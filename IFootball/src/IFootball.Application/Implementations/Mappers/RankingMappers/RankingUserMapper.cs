using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Core;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.RankingMappers;

public static class RankingUserMapper
{
    public static RankingUserDto ToRankingUserDto(this ScoreUser scoreUser)
    {
        return new RankingUserDto
        {
            Name = scoreUser.User.Name,
            Score = scoreUser.Score
        };
    }
}