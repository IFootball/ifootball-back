using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System.Net;
using System.Text.RegularExpressions;
using IFootball.Application.Contracts.Services.Core;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Responses.User;
using IFootball.Application.Implementations.Validators;
using IFootball.Domain.Models.enums;

namespace IFootball.Application.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IGenderRepository _genderRepository;
        private const string PATTERN_EMAIL_STUDENT_DOMAIN = "^(([a-z]+)\\.([a-z]+))(@aluno\\.feliz\\.ifrs\\.edu\\.br)$";
        private const string PATTERN_EMAIL_TECHER_DOMAIN = "^(([a-z]+)\\.([a-z]+))(@feliz\\.ifrs\\.edu\\.br)$";

        public UserService(IUserRepository userRepository, IClassRepository classRepository, ICurrentUserService currentUserService, IGenderRepository genderRepository)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
            _currentUserService = currentUserService;
            _genderRepository = genderRepository;
        }

        public async Task<LoginUserResponse> AuthenticateAsync(LoginUserRequest request)
        {
            var user = await _userRepository.GetUserAuthenticateAsync(request.Email, request.Password);

            if (user is null)
                return new LoginUserResponse(HttpStatusCode.Unauthorized, "Email ou senha incorretos!");

            return new LoginUserResponse(user.ToLoginUserDto());
        }

        public async Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest request)
        {
            var emailIsTeacher = Regex.Match(request.Email, PATTERN_EMAIL_TECHER_DOMAIN).Success;
            var emailIsStudent = Regex.Match(request.Email, PATTERN_EMAIL_STUDENT_DOMAIN).Success;
            if (!(emailIsTeacher || emailIsStudent))
                return new RegisterUserResponse(HttpStatusCode.BadRequest, "O email deve ser dominio do IFRS!");

            var userExists = await _userRepository.UserExistsByEmail(request.Email);
            if (userExists)
                return new RegisterUserResponse(HttpStatusCode.BadRequest, "O email já foi cadastrado!");

            var classExists = await _classRepository.ClassExistsById(request.IdClass);
            if (!classExists)
                return new RegisterUserResponse(HttpStatusCode.BadRequest, "A turma inserida não existe!");
            
            var user = request.ToUser();
            await _userRepository.CreateUserAsync(user);
            return new RegisterUserResponse(user.DtoToUserDto());
        }

        public async Task<DeleteUserResponse> DeleteAsync()
        {
            var idUser = _currentUserService.GetCurrentUserId();

            var user = await _userRepository.FindUserById(idUser);
            if (user is null)
                return new DeleteUserResponse(HttpStatusCode.NotFound, "O usuário não existe!");

            await _userRepository.DeleteUserAsync(user);
            return new DeleteUserResponse();
        }

        public async Task<EditUserResponse> EditAsync(EditUserRequest request)
        {
            var idUser = _currentUserService.GetCurrentUserId();
            
            var user = await _userRepository.FindUserById(idUser);
            if (user is null)
                return new EditUserResponse(HttpStatusCode.NotFound, "O usuário não existe!");
            
            if(request.NewPassword is not null && request.OldPassword is not null){
                var validPassword = await _userRepository.ValidatePasswordAsync(user.Password, request.OldPassword);
                if (!validPassword)
                    return new EditUserResponse(HttpStatusCode.Unauthorized, "Senha incorreta!");
                
                user.SetPassword(request.NewPassword);
                await _userRepository.EditPasswordUserAsync(user);
            }
            
            user.SetName(request.Name);
            await _userRepository.EditUserAsync(user);
            return new EditUserResponse(user.DtoToUserDto());
        }

        public async Task<GetScoreUserLogedResponse> GetScoreUserLogedAsync()
        {
            var idUser = _currentUserService.GetCurrentUserId();
            
            var scoreUser = await _userRepository.GetUserScore(idUser);
            if (scoreUser is null)
                return new GetScoreUserLogedResponse(HttpStatusCode.NotFound, "O usuário logado não existe!");

            var genderMale = await _genderRepository.FindByName(GenderName.Male);
            if (genderMale is null)
                return new GetScoreUserLogedResponse(HttpStatusCode.NotFound, "O gênero masculino não foi cadastrado!");
            var genderFemale = await _genderRepository.FindByName(GenderName.Female);
            if (genderFemale is null)
                return new GetScoreUserLogedResponse(HttpStatusCode.NotFound, "O gênero feminino não foi cadastrado!");
            
            return new GetScoreUserLogedResponse(scoreUser.ToScoreUserDto(genderMale.Id, genderFemale.Id));
        }
    }
}
