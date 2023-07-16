using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class DtoTeamClassMapper
{
    public static TeamClassDto ToTeamClassDto(this TeamClass teamClass)
    {
        return new TeamClassDto
        {
            IdGender = teamClass.IdGender,
            IdClass = teamClass.IdClass,
            TeamClassGoalkeepers = BuilderGoalkeeperDto(teamClass.TeamClassGoalkeepers),
            TeamClassLinePlayers = BuilderLinePlayerDto(teamClass.TeamClassLinePlayers),
        };
    }

    private static IEnumerable<GoalkeeperDto> BuilderGoalkeeperDto(List<Goalkeeper> goalkeepers)
    {
        return goalkeepers.Select(x => x.ToGoalkeeperDto());
    }
    private static IEnumerable<LinePlayerDto> BuilderLinePlayerDto(List<LinePlayer> linePlayers)
    {
        return linePlayers.Select(x => x.ToLinePlayerDto());
    }
}