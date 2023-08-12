using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Requests.Player;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Documents.Responses.Player;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Validators;
using IFootball.Core;
using IFootball.Domain.Contracts;
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
    public async Task<ActionResult<RegisterPlayerResponse>> Register([FromBody] RegisterPlayerRequest request)
    {
        var validationDto = new RegisterPlayerRequestValidator().Validate(request);
        if (!validationDto.IsValid)
            return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

        var response = await _playerService.RegisterAsync(request);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpPut]
    [Authorize(Roles = "Administrator")]
    [Route("{idPlayer}")]
    public async Task<ActionResult<EditPlayerResponse>> Edit([FromRoute] long idPlayer, [FromBody] EditPlayerRequest request)
    {
        var validationDto = new EditPlayerRequestValidator().Validate(request);
        if (!validationDto.IsValid)
            return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

        var response = await _playerService.EditAsync(idPlayer, request);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    [Route("{idPlayer}")]
    public async Task<ActionResult<GetPlayerResponse>> Get([FromRoute] long idPlayer)
    {
        var response = await _playerService.GetAsync(idPlayer);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpDelete]
    [Authorize(Roles = "Administrator")]
    [Route("{idPlayer}")]
    public async Task<ActionResult<DeletePlayerResponse>> Delete([FromRoute] long idPlayer)
    {
        var response = await _playerService.DeleteAsync(idPlayer);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return NoContent();
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<PagedResponse<SimplePlayerDto>>> GetAll(
        [FromQuery] Pageable pageable,
        [FromQuery] long? idGender,
        [FromQuery] long? playerType,
        [FromQuery] string? name = ""

        )
    {
        var response = await _playerService.GetAllAsync(idGender, playerType, name, pageable);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("all-ids")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<IdResponse>>> GetAllIds(
        [FromQuery] long? idGender,
        [FromQuery] long? playerType,
        [FromQuery] string? name = ""

    )
    {
        var response = await _playerService.GetAllIdAsync(idGender, playerType, name);
        return Ok(response);
    }

    [HttpPatch]
    [Authorize(Roles = "Administrator")]
    [Route("{idPlayer}")]
    public async Task<ActionResult<SetPlayerScoutResponse>> SetScout([FromRoute] long idPlayer, [FromBody] SetPlayerScoutRequest request)
    {
        var validationDto = new SetPlayerScoutRequestValidator().Validate(request);
        if (!validationDto.IsValid)
            return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

        var response = await _playerService.SetScoutAsync(idPlayer, request);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
}