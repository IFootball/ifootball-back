using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class DtoTeamUserMapper
{
    public static TeamUserDto ToTeamUserDto(this TeamUser teamUser)
    {
        return new TeamUserDto
        {
            IdCaptain = teamUser.IdCaptain,
            IdUser = teamUser.IdUser,
            IdGender = teamUser.IdGender,
            IdGoalkeeper = teamUser.IdGoalkeeper,
            IdLinePlayerFront = teamUser.IdLinePlayerMiddle,
            IdLinePlayerMiddle = teamUser.IdLinePlayerMiddle,
            IdLinePlayerBackRight = teamUser.IdLinePlayerBackRight,
            IdLinePlayerBackLeft = teamUser.IdLinePlayerBackLeft,
            IdReservePlayerOne = teamUser.IdReservePlayerOne,
            IdReservePlayerTwo = teamUser.IdReservePlayerTwo,
        };
    }
}     