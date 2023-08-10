using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterPlayerMapper
{
    public static Player ToPlayer(this RegisterPlayerRequest request)
    {
        return new Player(request.IdGender.GetValueOrDefault(), request.IdTeamClass.GetValueOrDefault(), request.Name, request.Image, request.PlayerType.GetValueOrDefault());
    }
}