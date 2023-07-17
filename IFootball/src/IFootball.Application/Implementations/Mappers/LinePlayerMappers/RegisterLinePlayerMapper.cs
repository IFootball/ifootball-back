using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterLinePlayerMapper
{
    public static Player ToLinePlayer(this RegisterLinePlayerRequest request)
    {
        return new Player(request.IdGender, request.IdTeamClass, request.Name, request.Image);
    }
}