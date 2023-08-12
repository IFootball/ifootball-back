using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;
using IFootball.Domain.Models.enums;

namespace IFootball.Application.Implementations.Mappers;

public static class SimpleDtoPlayerMapper
{
    public static SimplePlayerDto ToSimplePlayerDto(this Player player)
    {
        return new SimplePlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            ClassName = player.TeamClass.Class.Name,
            Image = player.Image,
            PlayerType = player.PlayerType,
            IdTeamClass = player.IdTeamClass,
            IdGender = player.IdGender,
        };
    }
}