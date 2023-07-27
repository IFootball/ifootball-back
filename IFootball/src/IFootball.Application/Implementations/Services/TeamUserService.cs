﻿using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System.Net;
using IFootball.Domain.Models.enums;
using Microsoft.AspNetCore.Http;
using IFootball.Application.Contracts.Services.Core;

namespace IFootball.Application.Implementations.Services
{
    public class TeamUserService : ITeamUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamUserRepository _teamUserRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ICurrentUserService _currentUserService;
        private static readonly DateTime LIMIT_DATE_EDIT_TEAM = new DateTime(2023, 9, 13, 12, 0, 0);

        public TeamUserService(IUserRepository userRepository, IPlayerRepository playerRepository, ITeamUserRepository teamUserRepository, IGenderRepository genderRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _playerRepository = playerRepository;
            _teamUserRepository = teamUserRepository;
            _genderRepository = genderRepository;
            _currentUserService = currentUserService; 
        }

        public async Task<RegisterTeamUserResponse> RegisterMaleAsync(RegisterTeamUserRequest teamUserRequest)
        {
            long idUser = _currentUserService.GetCurrentUserId();

            if(DateTime.Now > LIMIT_DATE_EDIT_TEAM)
                return new RegisterTeamUserResponse(HttpStatusCode.UnprocessableEntity, "O tempo de edição do time já passou!");

            
            if(ValidateUniquePlayers(teamUserRequest))
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O time não pode haver jogadores repetidos!");
            if(ValidateCaptainPlayer(teamUserRequest))
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O capitão deve estar no time!");
            
            
            var userExists = await _userRepository.UserExistsById(idUser);
            if (!userExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O usuário autenticado não existe!");
            var gender = await _genderRepository.FindByName(GenderName.Male);
            if(gender is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");

            
            var goalkeeper = await _playerRepository.FindCompleteById(teamUserRequest.IdGoalkeeper);
            if (goalkeeper is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não existe!");
            if (goalkeeper.PlayerType == PlayerType.Goalkeeper)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não é um goleiro!");
            if (goalkeeper.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro deve ser masculino!");
            
            var playerTwo = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerTwo);
            if (playerTwo is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois não existe!");
            if (playerTwo.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois não é um jogador linha!");
            if (playerTwo.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois deve ser masculino!");
            
            var playerOne = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerOne);
            if (playerOne is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um não existe!");
            if (playerOne.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um não é um jogador linha!");
            if (playerOne.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um deve ser masculino!");
            
            var playerThree = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerThree);
            if (playerThree is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três não existe!");
            if (playerThree.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três não é um jogador linha!");
            if (playerThree.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três deve ser masculino!");
            
            var playerFour = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerFour);
            if (playerFour is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro não existe!");
            if (playerFour.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro não é um jogador linha!");
            if (playerFour.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro deve ser masculino!");
            
            if (teamUserRequest.IdReservePlayerOne is not null)
            {
                var reservePlayerOne = await  _playerRepository.FindCompleteById(teamUserRequest.IdReservePlayerOne.GetValueOrDefault());
                if (reservePlayerOne is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva não existe!");
                if (reservePlayerOne.Gender.Name == GenderName.Male)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva deve ser masculino!");
            }
            if (teamUserRequest.IdReservePlayerTwo is not null)
            {
                var reservePlayerTwo = await  _playerRepository.FindCompleteById(teamUserRequest.IdReservePlayerTwo.GetValueOrDefault());
                if (reservePlayerTwo is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O segundo reserva não existe!");
                if (reservePlayerTwo.Gender.Name == GenderName.Male)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O segundo reserva deve ser masculino!");
            }
            
            var teamUser = await _teamUserRepository.FindTeamUserByIdUserAndIdGender(idUser, gender.Id);
            if (teamUser is null)
            {
                teamUser = teamUserRequest.ToTeamUser();
                teamUser.EditUser(idUser);
                teamUser.EditGender(gender.Id);
                await _teamUserRepository.CreateTeamUserAsync(teamUser);    
            }
            else
            {
                teamUser.EditReplaceTeam(teamUserRequest.ToTeamUser());
                await _teamUserRepository.EditTeamUserAsync(teamUser);
            }
            
            return new RegisterTeamUserResponse(teamUser.ToSimpleTeamUserDto());
        }
        
        public async Task<RegisterTeamUserResponse> RegisterFemaleAsync(RegisterTeamUserRequest teamUserRequest)
        {
            long idUser = _currentUserService.GetCurrentUserId();

            if (DateTime.Now > LIMIT_DATE_EDIT_TEAM)
                return new RegisterTeamUserResponse(HttpStatusCode.UnprocessableEntity, "O tempo de edição do time já passou!");

            
            if(ValidateUniquePlayers(teamUserRequest))
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O time não pode haver jogadores repetidos!");
            if(ValidateCaptainPlayer(teamUserRequest))
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O capitão deve estar no time!");
            
            
            var userExists = await _userRepository.UserExistsById(idUser);
            if (!userExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O usuário autenticado não existe!");
            var gender = await _genderRepository.FindByName(GenderName.Female);
            if(gender is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");

            
            var goalkeeper = await _playerRepository.FindCompleteById(teamUserRequest.IdGoalkeeper);
            if (goalkeeper is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não existe!");
            if (goalkeeper.PlayerType == PlayerType.Goalkeeper)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não é um goleiro!");
            if (goalkeeper.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro deve ser masculino!");
            
            var playerTwo = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerTwo);
            if (playerTwo is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois não existe!");
            if (playerTwo.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois não é um jogador linha!");
            if (playerTwo.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois deve ser masculino!");
            
            var playerOne = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerOne);
            if (playerOne is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um não existe!");
            if (playerOne.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um não é um jogador linha!");
            if (playerOne.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um deve ser masculino!");
            
            var playerThree = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerThree);
            if (playerThree is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três não existe!");
            if (playerThree.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três não é um jogador linha!");
            if (playerThree.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três deve ser masculino!");
            
            var playerFour = await  _playerRepository.FindCompleteById(teamUserRequest.IdLinePlayerFour);
            if (playerFour is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro não existe!");
            if (playerFour.PlayerType == PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro não é um jogador linha!");
            if (playerFour.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro deve ser masculino!");
            
            if (teamUserRequest.IdReservePlayerOne is not null)
            {
                var reservePlayerOne = await  _playerRepository.FindCompleteById(teamUserRequest.IdReservePlayerOne.GetValueOrDefault());
                if (reservePlayerOne is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva não existe!");
                if (reservePlayerOne.Gender.Name == GenderName.Female)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva deve ser masculino!");
            }
            if (teamUserRequest.IdReservePlayerTwo is not null)
            {
                var reservePlayerTwo = await  _playerRepository.FindCompleteById(teamUserRequest.IdReservePlayerTwo.GetValueOrDefault());
                if (reservePlayerTwo is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O segundo reserva não existe!");
                if (reservePlayerTwo.Gender.Name == GenderName.Female)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O segundo reserva deve ser masculino!");
            }
            
            var teamUser = await _teamUserRepository.FindTeamUserByIdUserAndIdGender(idUser, gender.Id);
            if (teamUser is null)
            {
                teamUser = teamUserRequest.ToTeamUser();
                teamUser.EditUser(idUser);
                teamUser.EditGender(gender.Id);
                await _teamUserRepository.CreateTeamUserAsync(teamUser);    
            }
            else
            {
                teamUser.EditReplaceTeam(teamUserRequest.ToTeamUser());
                await _teamUserRepository.EditTeamUserAsync(teamUser);
            }
            
            return new RegisterTeamUserResponse(teamUser.ToSimpleTeamUserDto());
        }

        public async Task<GetTeamUserResponse> GetMaleAsync()
        {
            long idUser = _currentUserService.GetCurrentUserId();
            
            var gender = await _genderRepository.FindByName(GenderName.Male);
            if(gender is null)
                return new GetTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");
            
            var teamUser = await _teamUserRepository.FindCompleteTeamUserByIdUserAndIdGender(idUser, gender.Id);
            if(teamUser is null)
                return new GetTeamUserResponse(HttpStatusCode.NotFound, "Não possui um time criado!");
            
            return new GetTeamUserResponse(teamUser.ToCompleteTeamUserDto());
        }

        public async Task<GetTeamUserResponse> GetFemaleAsync()
        {
            long idUser = _currentUserService.GetCurrentUserId();
            
            var gender = await _genderRepository.FindByName(GenderName.Female);
            if(gender is null)
                return new GetTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");
            
            var teamUser = await _teamUserRepository.FindTeamUserByIdUserAndIdGender(idUser, gender.Id);
            if(teamUser is null)
                return new GetTeamUserResponse(HttpStatusCode.NotFound, "Não possui um time criado!");
            
            return new GetTeamUserResponse(teamUser.ToCompleteTeamUserDto());
        }
        
        public bool ValidateUniquePlayers(RegisterTeamUserRequest request)
        {
            var idsPlayers = new List<long>();

            idsPlayers.Add(request.IdGoalkeeper);
            idsPlayers.Add(request.IdLinePlayerOne);
            idsPlayers.Add(request.IdLinePlayerTwo);
            idsPlayers.Add(request.IdLinePlayerThree);
            idsPlayers.Add(request.IdLinePlayerFour);

            if (request.IdReservePlayerOne is not null)
                idsPlayers.Add(request.IdReservePlayerOne.Value);
            if (request.IdReservePlayerTwo is not null)
                idsPlayers.Add(request.IdReservePlayerTwo.Value);
            
            return idsPlayers.Count != idsPlayers.Distinct().Count();
        }
        
        public bool ValidateCaptainPlayer(RegisterTeamUserRequest request)
        {
            var idsPlayers = new List<long>();

            idsPlayers.Add(request.IdGoalkeeper);
            idsPlayers.Add(request.IdLinePlayerOne);
            idsPlayers.Add(request.IdLinePlayerTwo);
            idsPlayers.Add(request.IdLinePlayerThree);
            idsPlayers.Add(request.IdLinePlayerFour);

            if (request.IdCaptain is null)
                return false;
            
            return !idsPlayers.Contains(request.IdCaptain.GetValueOrDefault());
        }
        
    }
}
