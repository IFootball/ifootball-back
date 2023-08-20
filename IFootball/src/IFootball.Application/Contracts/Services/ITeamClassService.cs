using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Domain.Contracts;

namespace IFootball.Application.Contracts.Services;

public interface ITeamClassService
{
    Task<RegisterTeamClassResponse> RegisterAsync(RegisterTeamClassRequest request);
    Task<DeleteTeamClassResponse> DeleteAsync(long idTeamClass);
    Task<EditTeamClassResponse> EditAsync(long idTeamClass, EditTeamClassRequest request);
    Task<GetTeamClassResponse> GetAsync(long idTeamClass);
    Task<PagedResponse<SimpleTeamClassDto>> ListAsync(Pageable pageable);
}