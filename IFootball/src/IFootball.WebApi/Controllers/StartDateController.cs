using System.Net;
using IFootball.Application.Contracts.Documents.Requests.StartDate;
using IFootball.Application.Contracts.Documents.Responses.StartDate;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers;

[ApiController]
[Route("api/start-dates")]
public class StartDateController : ControllerBase
{
    private readonly IStartDateService _startDateService;

    public StartDateController(IStartDateService startDateService)
    {
        _startDateService = startDateService;
    }
    
    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> EditStartDate(EditStartDateRequest request)
    {
        var validationDto = new EditStartDateRequestValidator().Validate(request);
        if (!validationDto.IsValid)
            return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
        
        var response = await _startDateService.EditStartDate(request);
                
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    } 
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<GetStartDateResponse>> GetStartDate()
    {
        var response = await _startDateService.GetStartDate();
                
        if (response.IsErrorStatusCode())
            return StatusCode((int)response.Error.StatusCode, response.Error.Message);

        return Ok(response);
    } 
}