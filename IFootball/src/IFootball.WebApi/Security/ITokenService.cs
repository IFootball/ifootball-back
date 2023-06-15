using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Domain.Models;

namespace IFootball.WebApi.Security
{
    public interface ITokenService
    {
        string GenerateToken(LoginUserResponse user);
    }
}
