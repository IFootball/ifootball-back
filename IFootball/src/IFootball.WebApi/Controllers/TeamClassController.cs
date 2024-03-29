﻿using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Application.Contracts.Documents.Requests.TeamClass;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Validators;
using IFootball.Domain.Contracts;
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
        [FromBody] RegisterTeamClassRequest request)
    {
        var validationDto = new RegisterTeamClassRequestValidator().Validate(request);
        if (!validationDto.IsValid)
            return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

        var response = await _teamClassService.RegisterAsync(request);
        
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpPut]
    [Authorize(Roles = "Administrator")]
    [Route("{idTeamClass}")]
    public async Task<ActionResult<EditTeamClassResponse>> Edit(
        [FromRoute] long idTeamClass,
        [FromBody] EditTeamClassRequest request)
    {
        var validationDto = new EditTeamClassRequestValidator().Validate(request);
        if (!validationDto.IsValid)
            return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

        var response = await _teamClassService.EditAsync(idTeamClass, request);
        
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpDelete]
    [Authorize(Roles = "Administrator")]
    [Route("{idTeamClass}")]
    public async Task<ActionResult<DeleteTeamClassResponse>> Delete(
        [FromRoute] long idTeamClass)
    {
        var response = await _teamClassService.DeleteAsync(idTeamClass);
        
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return NoContent();
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    [Route("{idTeamClass}")]
    public async Task<ActionResult<GetTeamClassResponse>> Get([FromRoute] long idTeamClass)
    {
        var response = await _teamClassService.GetAsync(idTeamClass);
        
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    }
    
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    [Route("list-player/{idTeamClass}")]
    public async Task<ActionResult<PagedResponse<TeamClassPlayerDto>>> ListPlayer(
        [FromRoute] long idTeamClass, 
        [FromQuery] Pageable pageable)
    {
        var response = await _teamClassService.ListPlayersAsync(idTeamClass, pageable);

        return Ok(response);
    }
    
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<PagedResponse<SimpleTeamClassDto>>> List([FromQuery] Pageable pageable) {
        var response = await _teamClassService.ListAsync(pageable);
        return Ok(response);
    }

}