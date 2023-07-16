using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterGoalkeeperMapper
{
    public static Goalkeeper ToGoalkeeper(this RegisterGoalkeeperRequest request)
    {
        return new Goalkeeper(request.IdGender, request.IdTeamClass, request.Name, request.Image);
    }
}