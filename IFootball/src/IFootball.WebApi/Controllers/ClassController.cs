using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Models;
using IFootball.Domain.Models.enums;
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
        public async Task<ActionResult<RegisterClassResponse>> Register([FromBody] RegisterClassRequest classRequest)
        {
            var response = await _classService.RegisterAsync(classRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("all")]
        public async Task<ActionResult<ListClassesResponse>> List()
        {
            var response = await _classService.ListAsync();

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }
    }
}
