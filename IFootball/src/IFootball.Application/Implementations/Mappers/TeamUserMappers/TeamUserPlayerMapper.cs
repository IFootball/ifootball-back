using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Domain.Contracts;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.RankingMappers;

public static class TeamUserPlayerMapper
{
    public static TeamUserPlayerDto ToTeamUserPlayerDto(this Player player)
    {
        return new TeamUserPlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Image = player.Image,
            Score = player.GetScore(),
        };
    }
}