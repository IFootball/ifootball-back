
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services
{
    public interface IClassService
    {
        Task<RegisterClassResponse> RegisterAsync(RegisterClassRequest resgiterClassRequest);
    }
}
