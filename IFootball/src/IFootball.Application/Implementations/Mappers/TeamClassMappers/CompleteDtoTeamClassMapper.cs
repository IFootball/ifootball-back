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
            TeamClassPlayers = BuilderSimplePlayerDto(teamClass.TeamClassPlayers),
        };
    }

    private static IEnumerable<SimplePlayerDto> BuilderSimplePlayerDto(List<Player> players)
    {
        return players.Select(x => x.ToSimplePlayerDto());
    }
}