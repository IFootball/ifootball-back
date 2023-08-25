using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Documents.Responses.User;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Validators;
using IFootball.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterUserResponse>> Register([FromBody] RegisterUserRequest request)
        {
            var validationDto = new RegisterUserRequestValidator().Validate(request);
            if (!validationDto.IsValid)
                return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
            
            var response = await _userService.RegisterAsync(request);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<LoginUserResponse>> Authenticate([FromBody] LoginUserRequest request)
        {
            var validationDto = new LoginUserRequestValidator().Validate(request);
            if (!validationDto.IsValid)
                return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
            
            var response = await _userService.AuthenticateAsync(request);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            response.Token = _tokenService.GenerateToken(response);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<LoginUserResponse>> DeleteAsync()
        {
            var response = await _userService.DeleteAsync();

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return NoContent();
        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<EditUserResponse>> EditAsync(EditUserRequest request)
        {
            var validationDto = new EditUserRequestValidator().Validate(request);
            if (!validationDto.IsValid)
                return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

            var response = await _userService.EditAsync(request);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok();
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GetScoreUserLogedResponse>> GetScoreUserLogedAsync()
        {
            var response = await _userService.GetScoreUserLogedAsync();

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }
  
    }
}
