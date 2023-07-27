using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;
using IFootball.Domain.Models.enums;

namespace IFootball.Application.Implementations.Mappers;

public static class CompleteDtoPlayerMapper
{
    public static CompletePlayerDto ToCompletePlayerDto(this Player player)
    {
        return new CompletePlayerDto
        {
            Id = player.Id,
            IdGender = player.IdGender,
            IdTeamClass = player.IdTeamClass,
            Name = player.Name,
            Image = player.Image,
            Goals = player.Goals,
            Assists = player.Assists,
            YellowCard = player.YellowCard,
            RedCard = player.RedCard,
            Fouls = player.Fouls,
            Wins = player.Wins,
            PlayerType = player.PlayerType,
            
            TakenGols = player.Goalkeeper?.TakenGols,
            PenaltySaves = player.Goalkeeper?.PenaltySaves,
            Saves = player.Goalkeeper?.Saves,
        };
    }
}