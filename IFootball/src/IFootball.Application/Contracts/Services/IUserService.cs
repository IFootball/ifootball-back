﻿using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Documents.Responses.User;

namespace IFootball.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest resgiterUserRequest);
        Task<LoginUserResponse> AuthenticateAsync(LoginUserRequest loginUserRequest);
        Task<DeleteUserResponse> DeleteAsync();
        Task<EditUserResponse> EditAsync(EditUserRequest editUserRequest);
        Task<GetScoreUserLogedResponse> GetScoreUserLogedAsync();
    }
}
