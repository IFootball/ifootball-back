using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System.Net;
using IFootball.Domain.Models.enums;
using IFootball.Application.Contracts.Services.Core;
using IFootball.Application.Implementations.Validators;

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

        public async Task<RegisterTeamUserResponse> RegisterAsync(RegisterTeamUserRequest request, long idGender)
        {
            if(DateTime.Now > LIMIT_DATE_EDIT_TEAM)
                return new RegisterTeamUserResponse(HttpStatusCode.UnprocessableEntity, "O tempo de edição do time já passou!");

            var idUser = _currentUserService.GetCurrentUserId();

            var userExists = await _userRepository.UserExistsById(idUser);
            if (!userExists)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O usuário autenticado não existe!");
            var gender = await _genderRepository.FindById(idGender);
            if(gender is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");

            
            var goalkeeper = await _playerRepository.FindCompleteById(request.IdGoalkeeper);
            if (goalkeeper is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não existe!");
            if (goalkeeper.PlayerType != PlayerType.Goalkeeper)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro escolhido não é um goleiro!");
            if (goalkeeper.Gender.Name != gender.Name)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O goleiro deve ser do gênero do time!");
            
            var playerTwo = await  _playerRepository.FindCompleteById(request.IdLinePlayerTwo);
            if (playerTwo is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois não existe!");
            if (playerTwo.PlayerType != PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois não é um jogador linha!");
            if (playerTwo.Gender.Name != gender.Name)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador dois deve ser do gênero do time!");
            
            var playerOne = await  _playerRepository.FindCompleteById(request.IdLinePlayerOne);
            if (playerOne is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um não existe!");
            if (playerOne.PlayerType != PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um não é um jogador linha!");
            if (playerOne.Gender.Name != gender.Name)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador um deve ser do gênero do time!");
            
            var playerThree = await  _playerRepository.FindCompleteById(request.IdLinePlayerThree);
            if (playerThree is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três não existe!");
            if (playerThree.PlayerType != PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três não é um jogador linha!");
            if (playerThree.Gender.Name != gender.Name)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador três deve ser do gênero do time!");
            
            var playerFour = await  _playerRepository.FindCompleteById(request.IdLinePlayerFour);
            if (playerFour is null)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro não existe!");
            if (playerFour.PlayerType != PlayerType.LinePlayer)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro não é um jogador linha!");
            if (playerFour.Gender.Name != gender.Name)
                return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O jogador quatro deve ser do gênero do time!");
            
            if (request.IdReservePlayerOne is not null)
            {
                var reservePlayerOne = await  _playerRepository.FindCompleteById(request.IdReservePlayerOne.GetValueOrDefault());
                if (reservePlayerOne is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva não existe!");
                if (reservePlayerOne.Gender.Name != gender.Name)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O primeiro reserva deve ser do gênero do time!");
            }
            if (request.IdReservePlayerTwo is not null)
            {
                var reservePlayerTwo = await  _playerRepository.FindCompleteById(request.IdReservePlayerTwo.GetValueOrDefault());
                if (reservePlayerTwo is null)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O segundo reserva não existe!");
                if (reservePlayerTwo.Gender.Name != gender.Name)
                    return new RegisterTeamUserResponse(HttpStatusCode.NotFound, "O segundo reserva deve ser do gênero do time!");
            }
            
            var teamUser = await _teamUserRepository.FindTeamUserByIdUserAndIdGender(idUser, gender.Id);
            if (teamUser is null)
            {
                teamUser = request.ToTeamUser();
                teamUser.EditUser(idUser);
                teamUser.EditGender(gender.Id);
                await _teamUserRepository.CreateTeamUserAsync(teamUser);    
            }
            else
            {
                teamUser.EditReplaceTeam(request.ToTeamUser());
                await _teamUserRepository.EditTeamUserAsync(teamUser);
            }
            
            return new RegisterTeamUserResponse(teamUser.ToSimpleTeamUserDto());
        }
        
        public async Task<GetTeamUserResponse> GetAsync(long idGender)
        {
            var idUser = _currentUserService.GetCurrentUserId();
            
            var gender = await _genderRepository.ExistsGenderById(idGender);
            if(!gender)
                return new GetTeamUserResponse(HttpStatusCode.NotFound, "O genêro escolhido não existe!");
            
            var teamUser = await _teamUserRepository.FindCompleteTeamUserByIdUserAndIdGender(idUser, idGender);
            if(teamUser is null)
                return new GetTeamUserResponse(HttpStatusCode.NotFound, "Não possui um time criado!");
            
            return new GetTeamUserResponse(teamUser.ToCompleteTeamUserDto());
        }
    }
}
