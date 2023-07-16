using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class DtoLinePlayerMapper
{
    public static LinePlayerDto ToLinePlayerDto(this LinePlayer linePlayer)
    {
        return new LinePlayerDto
        {
            IdGender = linePlayer.IdGender,
            IdTeamClass = linePlayer.IdTeamClass,
            Name = linePlayer.Name,
            Image = linePlayer.Image,
            Goals = linePlayer.Goals,
            Assists = linePlayer.Assists,
            YellowCard = linePlayer.YellowCard,
            RedCard = linePlayer.RedCard,
            Fouls = linePlayer.Fouls,
            Wins = linePlayer.Wins,
        };
    }
}