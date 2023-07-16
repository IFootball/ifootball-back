using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class DtoTeamUserMapper
{
    public static TeamUserDto ToTeamUserDto(this TeamUser teamUser)
    {
        return new TeamUserDto
        {
            IdUser = teamUser.IdUser,
            IdGender = teamUser.IdGender,
            IdGoalkeeper = teamUser.IdGoalkeeper,
            IdLinePlayerFrontLeft = teamUser.IdLinePlayerFrontLeft,
            IdLinePlayerFrontRight = teamUser.IdLinePlayerFrontRight,
            IdLinePlayerBackRight = teamUser.IdLinePlayerBackRight,
            IdLinePlayerBackLeft = teamUser.IdLinePlayerBackLeft,
        };
    }
}