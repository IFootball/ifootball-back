using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface IGoalkeeperService
{
    Task<RegisterGoalkeeperResponse> RegisterAsync(RegisterGoalkeeperRequest request);
    Task<DeleteGoalkeeperResponse> DeleteAsync(long idGoalkeeper);

}