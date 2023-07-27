using IFootball.Application.Contracts.Documents.Requests;
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
        private readonly IGoalkeeperRepository _goalkeeperRepository;
        private readonly IPlayerRepository _linePlayerRepository;
        private readonly ITeamUserRepository _teamUserRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ICurrentUserService _currentUserService;
        private static readonly DateTime LIMIT_DATE_EDIT_TEAM = new DateTime(2023, 9, 13, 12, 0, 0);

        public TeamUserService(IUserRepository userRepository, IGoalkeeperRepository goalkeeperRepository, IPlayerRepository linePlayerRepository, ITeamUserRepository teamUserRepository, IGenderRepository genderRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _goalkeeperRepository = goalkeeperRepository;
            _linePlayerRepository = linePlayerRepository;
            _teamUserRepository = teamUserRepository;
            _genderRepository = genderRepository;
            _currentUserService = currentUserService; 
        }

        public async Task<RegisterTeamUserResponse> RegisterMaleAsync(RegisterTeamUserRequest teamUserRequest)
        {
            long idUser = _currentUserService.GetCurrentUserId();

            if(DateTime.Now > LIMIT_DATE_EDIT_TEAM)
                return new RegisterTeamUserResponse(HttpStatusCode.UnprocessableEntity, "O tempo de edição do time já passou!");

            if(!ValidateTeamPlayer(teamUserRequest))
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O time não pode haver jogadores repetidos!");
            
            var userExists = await _userRepository.UserExistsById(idUser);
            if (!userExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O usuário autenticado não existe!");

            var gender = await _genderRepository.FindByName(GenderName.Male);
            if(gender is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");

            var goalkeeper = await _goalkeeperRepository.FindById(teamUserRequest.IdGoalkeeper);
            if (goalkeeper is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não existe!");
            if (goalkeeper.Player.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro deve ser masculino!");
            
            var linePlayerBackLeft = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerBackLeft);
            if (linePlayerBackLeft is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O zagueiro esquerdo escolhido não existe!");
            if (linePlayerBackLeft.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O zagueiro esquerdo deve ser masculino!");
            
            var linePlayerBackRight = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerBackRight);
            if (linePlayerBackRight is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O zagueiro direito escolhido não existe!");
            if (linePlayerBackRight.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O zagueiro direito deve ser masculino!");
            
            var linePlayerFrontRight = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerFront);
            if (linePlayerFrontRight is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O volante não existe!");
            if (linePlayerFrontRight.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O volante deve ser masculino!");
            
            var linePlayerFrontLeft = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerMiddle);
            if (linePlayerFrontLeft is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O atacante não existe!");
            if (linePlayerFrontLeft.Gender.Name == GenderName.Male)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O atacante deve ser masculino!");
            
            if (teamUserRequest.IdReservePlayerOne is not null)
            {
                var reservePlayerOne = await _linePlayerRepository.FindById(teamUserRequest.IdReservePlayerOne.GetValueOrDefault());
                if (reservePlayerOne is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva não existe!");
                if (reservePlayerOne.Gender.Name == GenderName.Male)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva deve ser masculino!");
            }
            if (teamUserRequest.IdReservePlayerTwo is not null)
            {
                var reservePlayerTwo = await _linePlayerRepository.FindById(teamUserRequest.IdReservePlayerTwo.GetValueOrDefault());
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
            
            return new RegisterTeamUserResponse(teamUser.ToTeamUserDto());
        }
        
        public async Task<RegisterTeamUserResponse> RegisterFemaleAsync(RegisterTeamUserRequest teamUserRequest)
        {

            long idUser = _currentUserService.GetCurrentUserId();

            if (DateTime.Now > LIMIT_DATE_EDIT_TEAM)
                return new RegisterTeamUserResponse(HttpStatusCode.UnprocessableEntity, "O tempo de edição do time já passou!");

            if(!ValidateTeamPlayer(teamUserRequest))
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O time não pode haver jogadoras repetidas!");
            
            var userExists = await _userRepository.UserExistsById(idUser);
            if (!userExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O usuário autenticado não existe!");

            var gender = await _genderRepository.FindByName(GenderName.Female);
            if(gender is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");

            var goalkeeper = await _goalkeeperRepository.FindById(teamUserRequest.IdGoalkeeper);
            if (goalkeeper is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A goleira escolhida não existe!");
            if (goalkeeper.Player.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A goleira deve ser feminina!");
            
            var linePlayerBackLeft = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerBackLeft);
            if (linePlayerBackLeft is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A zagueira esquerda escolhida não existe!");
            if (linePlayerBackLeft.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A zagueira esquerda deve ser feminina!");
            
            var linePlayerBackRight = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerBackRight);
            if (linePlayerBackRight is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A zagueira direita escolhida não existe!");
            if (linePlayerBackRight.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A zagueira direita deve ser feminina!");
            
            var linePlayerFrontRight = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerFront);
            if (linePlayerFrontRight is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A volante escolhida não existe!");
            if (linePlayerFrontRight.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A volante deve ser feminina!");
            
            var linePlayerFrontLeft = await _linePlayerRepository.FindById(teamUserRequest.IdLinePlayerMiddle);
            if (linePlayerFrontLeft is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A atacante escolhida não existe!");
            if (linePlayerFrontLeft.Gender.Name == GenderName.Female)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A atacante deve ser feminina!");
            
            if (teamUserRequest.IdReservePlayerOne is not null)
            {
                var reservePlayerOne = await _linePlayerRepository.FindById(teamUserRequest.IdReservePlayerOne.GetValueOrDefault());
                if (reservePlayerOne is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A primeira reserva não existe!");
                if (reservePlayerOne.Gender.Name == GenderName.Female)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A primeira reserva deve ser feminina!");
            }
            if (teamUserRequest.IdReservePlayerTwo is not null)
            {
                var reservePlayerTwo = await _linePlayerRepository.FindById(teamUserRequest.IdReservePlayerTwo.GetValueOrDefault());
                if (reservePlayerTwo is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A segunda reserva não existe!");  
                if (reservePlayerTwo.Gender.Name == GenderName.Female)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "A segunda reserva deve ser feminina!");
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
            
            return new RegisterTeamUserResponse(teamUser.ToTeamUserDto());
        }
        
        public bool ValidateTeamPlayer(RegisterTeamUserRequest request)
        {
            var uniqueIds = new HashSet<long>();

            uniqueIds.Add(request.IdGoalkeeper);
            uniqueIds.Add(request.IdLinePlayerFront);
            uniqueIds.Add(request.IdLinePlayerMiddle);
            uniqueIds.Add(request.IdLinePlayerBackRight);
            uniqueIds.Add(request.IdLinePlayerBackLeft);

            if (request.IdReservePlayerOne.HasValue)
                uniqueIds.Add(request.IdReservePlayerOne.Value);
        
            if (request.IdReservePlayerTwo.HasValue)
                uniqueIds.Add(request.IdReservePlayerTwo.Value);

            if (request.IdCaptain.HasValue && !uniqueIds.Contains(request.IdCaptain.Value))
                return false;

            return uniqueIds.Count == 7;
        }
    }
}
