using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterTeamUserMapper
{
    public static TeamUser ToTeamUser(this RegisterTeamUserRequest request)
    {
        return new TeamUser(
            request.IdGender,
            request.IdGoalkeeper,
            request.IdLinePlayerFrontLeft,
            request.IdLinePlayerFrontRight,
            request.IdLinePlayerBackRight,
            request.IdLinePlayerBackLeft
        );
    }
}
