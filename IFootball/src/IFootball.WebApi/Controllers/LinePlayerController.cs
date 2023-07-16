using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers;

[ApiController]
[Route("api/line-players")]
public class LinePlayerController : ControllerBase
{
    private readonly ILinePlayerService _linePlayerService;

    public LinePlayerController(ILinePlayerService linePlayerService)
    {
        _linePlayerService = linePlayerService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<RegisterLinePlayerResponse>> Register([FromBody] RegisterLinePlayerRequest linePlayerRequest)
    {
        var response = await _linePlayerService.RegisterAsync(linePlayerRequest);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    [HttpPut("{idLinePlayer}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<EditLinePlayerResponse>> Edit([FromRoute] long idLinePlayer,[FromBody] EditLinePlayerRequest linePlayerRequest)
    {
        var response = await _linePlayerService.EditAsync(idLinePlayer, linePlayerRequest);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    [HttpDelete("{idLinePlayer}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<DeleteLinePlayerResponse>> Delete([FromRoute] long idLinePlayer)
    {
        var response = await _linePlayerService.DeleteAsync(idLinePlayer);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpGet("{idLinePlayer}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<GetLinePlayerResponse>> Get([FromRoute] long idLinePlayer)
    {
        var response = await _linePlayerService.GetAsync(idLinePlayer);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
}