using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Models;
using IFootball.WebApi.Security;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UsuarioController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginUserResponse>> Authenticate([FromBody] LoginUserRequest userRequest)
        {
            var user = await _userService.AuthenticateAsync(userRequest);

            if (user is null)
                return NotFound();

            user.Token = _tokenService.GenerateToken(user);

            return Ok(user);
        }
    }
}
