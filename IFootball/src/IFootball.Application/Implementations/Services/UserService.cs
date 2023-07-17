using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System.Net;
using System.Text.RegularExpressions;
using IFootball.Application.Contracts.Services.Core;

namespace IFootball.Application.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;
        private readonly ICurrentUserService _currentUserService;
        private const string PATTERN_EMAIL_STUDENT_DOMAIN = "^(([a-z]+)\\.([a-z]+))(@aluno\\.feliz\\.ifrs\\.edu\\.br)$";
        private const string PATTERN_EMAIL_TECHER_DOMAIN = "^(([a-z]+)\\.([a-z]+))(@feliz\\.ifrs\\.edu\\.br)$";

        public UserService(IUserRepository userRepository, IClassRepository classRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
            _currentUserService = currentUserService;
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
            var emailIsTeacher = Regex.Match(registerUserRequest.Email, PATTERN_EMAIL_TECHER_DOMAIN).Success;
            var emailIsStudent = Regex.Match(registerUserRequest.Email, PATTERN_EMAIL_STUDENT_DOMAIN).Success;
            if (!(emailIsTeacher || emailIsStudent))
                return new RegisterUserResponse(HttpStatusCode.BadRequest, "O email deve ser dominio do IFRS!");

            var userExists = await _userRepository.UserExistsByEmail(registerUserRequest.Email);
            if (userExists)
                return new RegisterUserResponse(HttpStatusCode.BadRequest, "O email já foi cadastrado!");

            var classExists = await _classRepository.ClassExistsById(registerUserRequest.IdClass);
            if (!classExists)
                return new RegisterUserResponse(HttpStatusCode.BadRequest, "A turma inserida não existe!");

            var user = registerUserRequest.ToUser();
            await _userRepository.CreateUserAsync(user);
            return new RegisterUserResponse(user.DtoToUserDto());
        }

        public async Task<DeleteUserResponse> DeleteAsync()
        {
            long idUser = _currentUserService.GetCurrentUserId();

            var user = await _userRepository.FindUserById(idUser);
            if (user is null)
                return new DeleteUserResponse(HttpStatusCode.NotFound, "O usuário não existe!");

            await _userRepository.DeleteUserAsync(user);
            return new DeleteUserResponse();
        }

        public async Task<EditUserResponse> EditAsync(EditUserRequest editUserRequest)
        {
            long idUser = _currentUserService.GetCurrentUserId();

            var emailIsTeacher = Regex.Match(editUserRequest.Email, PATTERN_EMAIL_TECHER_DOMAIN).Success;
            var emailIsStudent = Regex.Match(editUserRequest.Email, PATTERN_EMAIL_STUDENT_DOMAIN).Success;
            if (!(emailIsTeacher || emailIsStudent))
                return new EditUserResponse(HttpStatusCode.BadRequest, "O email deve ser dominio do IFRS!");

            var classExists = await _classRepository.ClassExistsById(editUserRequest.IdClass);
            if (!classExists)
                return new EditUserResponse(HttpStatusCode.BadRequest, "A turma inserida não existe!");
            
            var user = await _userRepository.FindUserById(idUser);
            if (user is null)
                return new EditUserResponse(HttpStatusCode.NotFound, "O usuário não existe!");
            
            if (editUserRequest.Email != user.Email)
            {
                var userExists = await _userRepository.UserExistsByEmail(editUserRequest.Email);
                if (userExists)
                    return new EditUserResponse(HttpStatusCode.BadRequest, "O email já foi cadastrado!");    
            }
            
            user.Edit(editUserRequest.IdClass, editUserRequest.Name, editUserRequest.Email);
            await _userRepository.EditUserAsync(user);
            return new EditUserResponse(user.DtoToUserDto());
        }
    }
}
