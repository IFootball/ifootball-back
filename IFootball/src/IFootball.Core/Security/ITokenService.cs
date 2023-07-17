using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Core.Security
{
    public interface ITokenService
    {
        string GenerateToken(LoginUserResponse user);
    }
}
