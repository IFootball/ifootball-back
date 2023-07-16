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
            request.IdLinePlayerFront,
            request.IdLinePlayerMiddle,
            request.IdLinePlayerBackRight,
            request.IdLinePlayerBackLeft,
            request.IdReservePlayerOne,
            request.IdReservePlayerTwo
        );
    }
}
