using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class SimpleDtoTeamUserMapper
{
    public static SimpleTeamUserDto ToSimpleTeamUserDto(this TeamUser teamUser)
    {
        return new SimpleTeamUserDto
        {
            IdCaptain = teamUser.IdCaptain,
            IdUser = teamUser.IdUser,
            IdGender = teamUser.IdGender,
            IdGoalkeeper = teamUser.IdGoalkeeper,
            IdPlayerOne = teamUser.IdPlayerOne,
            IdPlayerTwo = teamUser.IdPlayerTwo,
            IdPlayerThree = teamUser.IdPlayerThree,
            IdPlayerFour = teamUser.IdPlayerFour,
            IdReservePlayerOne = teamUser.IdReservePlayerOne,
            IdReservePlayerTwo = teamUser.IdReservePlayerTwo,
        };
    }
}     