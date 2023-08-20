using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Contracts;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class TeamClassDtoPlayerMapper
{
    public static TeamClassPlayerDto ToTeamClassPlayerDto(this ScorePlayer player)
    {
        return new TeamClassPlayerDto{
            Id = player.Player.Id,
            Name = player.Player.Name,
            Score = player.Score,
        };
    }
}