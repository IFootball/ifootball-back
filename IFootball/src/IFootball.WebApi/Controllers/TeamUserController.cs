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
        [Route("male")]
        public async Task<ActionResult<RegisterTeamUserResponse>> RegisterMale([FromBody] RegisterTeamUserRequest teamUserRequest)
        {
            var idUserLogged = long.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("Id"))?.Value);

            var response = await _teamUserService.RegisterMaleAsync(idUserLogged, teamUserRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }
        
        [HttpPost]
        [Authorize]
        [Route("famale")]
        public async Task<ActionResult<RegisterTeamUserResponse>> RegisterFamale([FromBody] RegisterTeamUserRequest teamUserRequest)
        {
            var idUserLogged = long.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("Id"))?.Value);

            var response = await _teamUserService.RegisterFemaleAsync(idUserLogged, teamUserRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }
        
        /*
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<GetTeamUserResponse>> GetMale() {
            var idUserLogged = long.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("Id"))?.Value);

            var response = await _teamUserService.GetMaleAsync(idUserLogged);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }
        */
    }
}
