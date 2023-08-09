using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Core;
using IFootball.Domain.Contracts;
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
    
    public static RankingPlayerDto ToRankingPlayerDto(this ScorePlayer scorePlayer)
    {
        return new RankingPlayerDto
        {
            Name = scorePlayer.Player.Name,
            Score = scorePlayer.Score
        };
    }
}