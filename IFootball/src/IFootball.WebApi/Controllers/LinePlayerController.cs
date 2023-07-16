using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers;

[ApiController]
[Route("api/line-player")]
public class LinePlayerController : ControllerBase
{
    private readonly ILinePlayerService _linePlayerService;

    public LinePlayerController(ILinePlayerService linePlayerService)
    {
        _linePlayerService = linePlayerService;
    }

    [HttpPost]
    [Route("register")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<RegisterLinePlayerResponse>> Register([FromBody] RegisterLinePlayerRequest linePlayerRequest)
    {
        var response = await _linePlayerService.RegisterAsync(linePlayerRequest);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
}