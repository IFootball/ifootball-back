using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers;

[ApiController]
[Route("api/players")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<RegisterPlayerResponse>> Register([FromBody] RegisterPlayerRequest playerRequest)
    {
        var response = await _playerService.RegisterAsync(playerRequest);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    [HttpPut("{idPlayer}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<EditPlayerResponse>> Edit([FromRoute] long idPlayer, [FromBody] EditPlayerRequest linePlayerRequest)
    {
        var response = await _playerService.EditAsync(idPlayer, linePlayerRequest);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpGet("{idPlayer}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<GetLinePlayerResponse>> Get([FromRoute] long idPlayer)
    {
        var response = await _playerService.GetAsync(idPlayer);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpDelete("{idPlayer}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<DeletePlayerResponse>> Delete([FromRoute] long idPlayer)
    {
        var response = await _playerService.DeleteAsync(idPlayer);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return NoContent();
    }
}