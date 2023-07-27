using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterTeamUserMapper
{
    public static TeamUser ToTeamUser(this RegisterTeamUserRequest request)
    {
        return new TeamUser(
            request.IdCaptain,
            request.IdGoalkeeper,
            request.IdLinePlayerOne,
            request.IdLinePlayerTwo,
            request.IdLinePlayerThree,
            request.IdLinePlayerFour,
            request.IdReservePlayerOne,
            request.IdReservePlayerTwo
        );
    }
}
