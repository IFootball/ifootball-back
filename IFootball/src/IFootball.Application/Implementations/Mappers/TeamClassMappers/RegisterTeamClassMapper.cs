using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.TeamClassMappers;

public static class RegisterTeamClassMapper
{
    public static TeamClass ToTeamClass(this RegisterTeamClassRequest request)
    {
        return new TeamClass(request.IdGender, request.IdClass);
    }
}