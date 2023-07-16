using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services;

public interface IGoalkeeperService
{
    Task<RegisterGoalkeeperResponse> RegisterAsync(RegisterGoalkeeperRequest request);
    Task<EditGoalkeeperResponse> EditAsync(long idGoalkeeper, EditGoalkeeperRequest request);
    Task<GetGoalkeeperResponse> GetAsync(long idGoalkeeper);
    Task<DeleteGoalkeeperResponse> DeleteAsync(long idGoalkeeper);

}