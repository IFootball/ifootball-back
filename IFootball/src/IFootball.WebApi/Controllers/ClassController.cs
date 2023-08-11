using System.Net;
using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<RegisterClassResponse>> Register([FromBody] RegisterClassRequest request)
        {
            var validationDto = new RegisterClassRequestValidator().Validate(request);
            if(!validationDto.IsValid)
                return StatusCode((int)HttpStatusCode.BadRequest, validationDto.Errors.Select(e => e.ErrorMessage).FirstOrDefault());

            var response = await _classService.RegisterAsync(request);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ClassDto>>> List()
        {
            var response = await _classService.ListAsync();

            return Ok(response);
        }
    }
}
