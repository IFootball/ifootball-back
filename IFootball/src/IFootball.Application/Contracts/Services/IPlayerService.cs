using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Requests.Player;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Documents.Responses.Player;
using IFootball.Core;
using IFootball.Domain.Contracts;

namespace IFootball.Application.Contracts.Services;

public interface IPlayerService
{
    Task<RegisterPlayerResponse> RegisterAsync(RegisterPlayerRequest request);
    Task<EditPlayerResponse> EditAsync(long idPlayer, EditPlayerRequest request);
    Task<GetPlayerResponse> GetAsync(long idPlayer);
    Task<DeletePlayerResponse> DeleteAsync(long idPlayer);
    Task<PagedResponse<SimplePlayerDto>> GetAllAsync(long? idGender, long? playerType, string name, Pageable pageable);
    Task<SetPlayerScoutResponse> SetScoutAsync(long idPlayer, SetPlayerScoutRequest request);
    Task<IEnumerable<IdResponse>> GetAllIdAsync(long? idGender, long? playerType, string? name);
}