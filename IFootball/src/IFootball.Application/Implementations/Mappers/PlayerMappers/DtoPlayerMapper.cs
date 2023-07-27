using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class DtoPlayerMapper
{
    public static PlayerDto ToPlayerDto(this Player player)
    {
        return new PlayerDto
        {
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
        };
    }
}