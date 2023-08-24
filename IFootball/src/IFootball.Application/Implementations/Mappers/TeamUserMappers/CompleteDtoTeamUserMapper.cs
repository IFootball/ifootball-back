using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class CompleteDtoTeamUserMapper
{
    public static CompleteTeamUserDto ToCompleteTeamUserDto(this TeamUser teamUser)
    {
        return new CompleteTeamUserDto
        {
          Gender = teamUser.Gender.Name,
          IdCaptain = teamUser.IdCaptain,
          Goalkeeper = teamUser.Goalkeeper.ToSimplePlayerDto(),
          LinePlayerOne = teamUser.PlayerOne.ToSimplePlayerDto(),
          LinePlayerTwo = teamUser.PlayerTwo.ToSimplePlayerDto(),
          LinePlayerThree = teamUser.PlayerThree.ToSimplePlayerDto(),
          LinePlayerFour = teamUser.PlayerFour.ToSimplePlayerDto(),
          ReservePlayerOne = teamUser.ReservePlayerOne.ToSimplePlayerDto(),
          ReservePlayerTwo = teamUser.ReservePlayerTwo.ToSimplePlayerDto(),
        };
    }
}     