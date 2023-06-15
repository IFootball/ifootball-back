using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var response = new LoginUserResponse();

            var user = await _userRepository.GetUserAuthenticateAsync(loginUserRequest.Email, loginUserRequest.Password);

            if (user == null)
            {
                return response;
            }
            
            response.User = new LoginUserDto { Id = user.Id };
            return response;

        }
    }
}
