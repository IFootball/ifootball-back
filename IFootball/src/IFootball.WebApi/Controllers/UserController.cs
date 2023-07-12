using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.WebApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<ActionResult<RegisterUserResponse>> Register([FromBody] RegisterUserRequest userRequest)
        {
            var response = await _userService.RegisterAsync(userRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<LoginUserResponse>> Authenticate([FromBody] LoginUserRequest userRequest)
        {
            var response = await _userService.AuthenticateAsync(userRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            response.Token = _tokenService.GenerateToken(response);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        [Route("delete")]
        public async Task<ActionResult<LoginUserResponse>> DeleteAsync()
        {
            var idUserLogged = long.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("Id"))?.Value);

            var response = await _userService.DeleteAsync(idUserLogged);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return NoContent();
        }

        [HttpPut]
        [Authorize]
        [Route("edit")]
        public async Task<ActionResult<EditUserResponse>> EditAsync(EditUserRequest editUserRequest)
        {
            var idUserLogged = long.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("Id"))?.Value);

            var response = await _userService.EditAsync(idUserLogged, editUserRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok();
        }

    }
}
