using System.Net;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IFootball.Application.Implementations.Validators;

namespace IFootball.WebApi.Controllers
{
    [ApiController]
    [Route("api/team-users")]
    public class TeamUserController : ControllerBase
    {
        private readonly ITeamUserService _teamUserService;

        public TeamUserController(ITeamUserService teamUserService)
        {
            _teamUserService = teamUserService;
        }

        [HttpPost]
        [Authorize]
        [Route("{idGender}")]
        public async Task<ActionResult<RegisterTeamUserResponse>> Register(
            [FromRoute] long idGender, [FromBody] RegisterTeamUserRequest request)
        {

            var validationDto = new RegisterTeamUserRequestValidator().Validate(request);
            if (!validationDto.IsValid)
                return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
            
            var response = await _teamUserService.RegisterAsync(request, idGender);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }

        [HttpGet]
        [Route("{idGender}")]
        [Authorize]
        public async Task<ActionResult<GetTeamUserResponse>> Get([FromRoute] long idGender) {
            var response = await _teamUserService.GetAsync(idGender);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }
    }
}
