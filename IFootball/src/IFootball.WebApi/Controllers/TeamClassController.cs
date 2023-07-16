using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers;

[ApiController]
[Route("api/team-classes")]
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
    
    [HttpPut("{idTeamClass}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<EditTeamClassResponse>> Edit(
        [FromRoute] long idTeamClass,
        [FromBody] EditTeamClassRequest requestTeamClass)
    {
        var response = await _teamClassService.EditAsync(idTeamClass, requestTeamClass);
        
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

    [HttpGet("{idTeamClass}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<GetTeamClassResponse>> Get([FromRoute] long idTeamClass)
    {
        var response = await _teamClassService.GetAsync(idTeamClass);
        
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<SimpleTeamClassDto>>> List() {
        var response = await _teamClassService.ListAsync();
        return Ok(response);
    }

}