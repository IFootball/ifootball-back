using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.RankingMappers;

public static class RankingPlayerMapper
{
    public static RankingPlayerDto ToRankingPlayerDto(this Player player, int score)
    {
        return new RankingPlayerDto
        {
            Name = player.Name,
            Score = score
        };
    }
}