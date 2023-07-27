using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface IPlayerService
{
    Task<RegisterPlayerResponse> RegisterAsync(RegisterPlayerRequest request);
    Task<EditPlayerResponse> EditAsync(long idPlayer, EditPlayerRequest request);
    Task<GetPlayerResponse> GetAsync(long idPlayer);
    Task<DeletePlayerResponse> DeleteAsync(long idPlayer);

}