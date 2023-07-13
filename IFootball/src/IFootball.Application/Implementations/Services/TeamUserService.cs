﻿using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System.Net;
using System.Text.RegularExpressions;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Services
{
    public class TeamUserService : ITeamUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamUserRepository _teamUserRepository;
        private readonly IGenderRepository _genderRepository;

        public TeamUserService(IUserRepository userRepository, ITeamUserRepository teamUserRepository, IGenderRepository genderRepository)
        {
            _userRepository = userRepository;
            _teamUserRepository = teamUserRepository;
            _genderRepository = genderRepository;
        }

        public async Task<RegisterTeamUserResponse> RegisterAsync(long idUser, RegisterTeamUserRequest teamUserRequest)
        {
            var userExists = await _userRepository.UserExistsById(idUser);
            if (!userExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O usuário autenticado não existe!");

            var genderExists = await _genderRepository.ExistsGenderById(teamUserRequest.IdGender);
            if(!genderExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");
            /*
            var goalkeeperExists = await _userRepository.UserExistsById(teamUserRequest.IdGoalkeeper);
            if (!goalkeeperExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não existe!");
            var linePlayerBackLeftExists = await _userRepository.UserExistsById(teamUserRequest.IdLinePlayerBackLeft);
            if (!linePlayerBackLeftExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O zagueiro esquerdo escolhido não existe!");
            var linePlayerBackRightExists = await _userRepository.UserExistsById(teamUserRequest.IdLinePlayerBackRight);
            if (!linePlayerBackRightExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O zagueiro direito escolhido não existe!");
            var linePlayerFrontRightExists = await _userRepository.UserExistsById(teamUserRequest.IdLinePlayerFrontRight);
            if (!linePlayerFrontRightExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O atacante direito não existe!");
            var linePlayerFrontLeftExists = await _userRepository.UserExistsById(teamUserRequest.IdLinePlayerFrontLeft);
            if (!linePlayerFrontLeftExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O atacante esquerdo não existe!");
*/
            var teamUser = teamUserRequest.ToTeamUser();
            teamUser.AddUser(idUser);
            await _teamUserRepository.CreateTeamUserAsync(teamUser);
            return new RegisterTeamUserResponse(teamUser.ToTeamUserDto());
        }

        /*
        public async Task<EditUserResponse> EditAsync(long idUser, EditUserRequest editUserRequest)
        {
            var user = await _userRepository.FindUserById(idUser);
            if (user is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O usuário autenticado não existe!");
            

            user.EditIdClass(editUserRequest.IdClass);
            user.EditName(editUserRequest.Name);
            user.EditEmail(editUserRequest.Email);
            
            await _userRepository.EditUserAsync(user);
            return new EditUserResponse(user.toUserDto());
        }
        */
    }
}
