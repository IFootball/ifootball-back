using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class CompleteDtoTeamClassMapper
{
    public static CompleteTeamClassDto ToCompleteTeamClassDto(this TeamClass teamClass)
    {
        return new CompleteTeamClassDto
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