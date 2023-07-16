using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class DtoGoalkeeperMapper
{
    public static GoalkeeperDto ToGoalkeeperDto(this Goalkeeper goalkeeper)
    {
        return new GoalkeeperDto
        {
            IdGender = goalkeeper.IdGender,
            IdTeamClass = goalkeeper.IdTeamClass,
            Name = goalkeeper.Name,
            Image = goalkeeper.Image,
            Goals = goalkeeper.Goals,
            Assists = goalkeeper.Assists,
            YellowCard = goalkeeper.YellowCard,
            RedCard = goalkeeper.RedCard,
            Fouls = goalkeeper.Fouls,
            Wins = goalkeeper.Wins,
            TakenGols = goalkeeper.TakenGols,
            PenaltySaves = goalkeeper.PenaltySaves,
            Saves = goalkeeper.Saves,
        };
    }
}