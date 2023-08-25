using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Domain.Contracts;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.RankingMappers;

public static class RankingPlayerMapper
{
    public static RankingPlayerDto ToRankingPlayerDto(this ScorePlayer player)
    {
        return new RankingPlayerDto
        {
            Name = player.Player.Name,
            Image = player.Player.Image,
            Score = player.Score,
        };
    }
    public static RankingPlayerDto ToRankingPlayerDto(this Player player, int score)
    {
        return new RankingPlayerDto
        {
            Name = player.Name,
            Image = player.Image,
            Score = score
        };
    }
}