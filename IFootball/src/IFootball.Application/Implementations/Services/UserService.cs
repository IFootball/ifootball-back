using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Implementations.Mappers;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Contracts.Repositories;
using System.Net;
using IFootball.Core;
using System.Text.RegularExpressions;

namespace IFootball.Application.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;
        private const string PATTERN_EMAIL_STUDENT_DOMAIN = "^(([a-z]+)\\.([a-z]+))(@aluno\\.feliz\\.ifrs\\.edu\\.br)$";
        private const string PATTERN_EMAIL_TECHER_DOMAIN = "^(([a-z]+)\\.([a-z]+))(@feliz\\.ifrs\\.edu\\.br)$";

        public UserService(IUserRepository userRepository, IClassRepository classRepository)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
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

            var user = registerUserRequest.toUser();
            await _userRepository.CreateUserAsync(user);
            return new RegisterUserResponse(user.toUserDto());
        }
    }
}
