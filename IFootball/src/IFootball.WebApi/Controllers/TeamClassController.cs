using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers;

[ApiController]
[Route("api/team-class")]
public class TeamClassController : ControllerBase
{
    private readonly ITeamClassService _teamClassService;

    public TeamClassController(ITeamClassService teamClassService)
    {
        _teamClassService = teamClassService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<RegisterTeamClassResponse>> Register(
        [FromBody] RegisterTeamClassRequest requestTeamClass)
    {
        var response = await _teamClassService.RegisterAsync(requestTeamClass);
        
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpDelete("{idTeamClass}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<DeleteTeamClassResponse>> Delete(
        [FromRoute] long idTeamClass)
    {
        var response = await _teamClassService.DeleteAsync(idTeamClass);
        
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return NoContent();
    }
}