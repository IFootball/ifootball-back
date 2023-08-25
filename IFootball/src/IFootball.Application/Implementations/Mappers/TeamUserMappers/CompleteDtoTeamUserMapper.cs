using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Implementations.Mappers.RankingMappers;
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
          Goalkeeper = teamUser.Goalkeeper.ToTeamUserPlayerDto(),
          LinePlayerOne = teamUser.PlayerOne.ToTeamUserPlayerDto(),
          LinePlayerTwo = teamUser.PlayerTwo.ToTeamUserPlayerDto(),
          LinePlayerThree = teamUser.PlayerThree.ToTeamUserPlayerDto(),
          LinePlayerFour = teamUser.PlayerFour.ToTeamUserPlayerDto(),
          ReservePlayerOne = teamUser.ReservePlayerOne.ToTeamUserPlayerDto(),
          ReservePlayerTwo = teamUser.ReservePlayerTwo.ToTeamUserPlayerDto(),
        };
    }
}     