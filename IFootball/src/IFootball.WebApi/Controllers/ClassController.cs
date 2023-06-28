using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Application.Contracts.Services;
using IFootball.Domain.Models;
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
        [Authorize]
        public async Task<ActionResult<RegisterClassResponse>> Register([FromBody] RegisterClassRequest classRequest)
        {
            var response = await _classService.RegisterAsync(classRequest);

            if (response.IsErrorStatusCode())
                return StatusCode((int)response.Error.StatusCode, response.Error.Message);

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
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
