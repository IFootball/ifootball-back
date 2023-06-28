using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System.Net;
using IFootball.Core;

namespace IFootball.Application.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginUserResponse> AuthenticateAsync(LoginUserRequest loginUserRequest)
        {
            var user = await _userRepository.GetUserAuthenticateAsync(loginUserRequest.Email, loginUserRequest.Password);

            if (user is null)
                return new LoginUserResponse(HttpStatusCode.Unauthorized, "Email ou senha incorretos!");

            return new LoginUserResponse(user.ToLoginUserDto());
        }

        public async Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest registerUserRequest)
        {

            // validacao dados


            var user = registerUserRequest.toUser();
            await _userRepository.CreateUserAsync(user);
            return new RegisterUserResponse(user.toUserDto());
        }
    }
}
