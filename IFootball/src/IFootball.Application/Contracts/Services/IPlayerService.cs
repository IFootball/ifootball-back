using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface IPlayerService
{
    Task<RegisterPlayerResponse> RegisterAsync(RegisterPlayerRequest request);
    Task<EditLinePlayerResponse> EditAsync(long idLinePlayer, EditLinePlayerRequest request);
    Task<GetLinePlayerResponse> GetAsync(long idLinePlayer);
    Task<DeleteLinePlayerResponse> DeleteAsync(long idLinePlayer);

}