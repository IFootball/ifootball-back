using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers;

[ApiController]
[Route("api/goalkeeper")]
public class GoalkeeperController : ControllerBase
{
    private readonly IGoalkeeperService _goalkeeperService;

    public GoalkeeperController(IGoalkeeperService goalkeeperService)
    {
        _goalkeeperService = goalkeeperService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<RegisterGoalkeeperResponse>> Register([FromBody] RegisterGoalkeeperRequest goalkeeperRequest)
    {
        var response = await _goalkeeperService.RegisterAsync(goalkeeperRequest);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<EditGoalkeeperResponse>> Edit([FromRoute] long idGoalkeeper, [FromBody] EditGoalkeeperRequest goalkeeperRequest)
    {
        var response = await _goalkeeperService.EditAsync(idGoalkeeper, goalkeeperRequest);

        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpDelete]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<DeleteGoalkeeperResponse>> Delete([FromRoute] long idGoalkeeper)
    {
        var response = await _goalkeeperService.DeleteAsync(idGoalkeeper);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return NoContent();
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<GetGoalkeeperResponse>> Get([FromRoute] long idGoalkeeper)
    {
        var response = await _goalkeeperService.GetAsync(idGoalkeeper);
        
        if(response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
}