using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;

namespace IFootball.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest resgiterUserRequest);
        Task<LoginUserResponse> AuthenticateAsync(LoginUserRequest loginUserRequest);
        Task<DeleteUserResponse> DeleteAsync(long idUser);
        Task<EditUserResponse> EditAsync(long idUser, EditUserRequest editUserRequest);
    }
}
