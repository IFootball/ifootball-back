using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface ITeamClassService
{
    Task<RegisterTeamClassResponse> RegisterAsync(RegisterTeamClassRequest request);
    Task<DeleteTeamClassResponse> DeleteAsync(long idTeamClass);
    Task<EditTeamClassResponse> EditAsync(long idTeamClass, EditTeamClassRequest requestTeamClass);
    Task<GetTeamClassResponse> GetAsync(long idTeamClass);
    Task<IEnumerable<SimpleTeamClassDto>> ListAsync();
}