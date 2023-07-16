using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterLinePlayerMapper
{
    public static LinePlayer ToLinePlayer(this RegisterLinePlayerRequest request)
    {
        return new LinePlayer(request.IdGender, request.IdTeamClass, request.Name, request.Image);
    }
}