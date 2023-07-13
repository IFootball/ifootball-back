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
    [Route("api/team-user")]
    public class TeamUserController : ControllerBase
    {
        private readonly ITeamUserService _teamUserService;

        public TeamUserController(ITeamUserService teamUserService)
        {
            _teamUserService = teamUserService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RegisterTeamUserResponse>> Register([FromBody] RegisterTeamUserRequest teamUserRequest)
        {
            var idUserLogged = long.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("Id"))?.Value);

            var response = await _teamUserService.RegisterAsync(idUserLogged, teamUserRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }

/*
        [HttpPut]
        [Authorize]
        [Route("edit")]
        public async Task<ActionResult<EditTeamUserResponse>> EditAsync(EditTeamUserRequest editTeamUserRequest)
        {
            var idUserLogged = long.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("Id"))?.Value);

            var response = await _teamUserService.EditAsync(idUserLogged, editTeamUserRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok();
        }
*/
    }
}
