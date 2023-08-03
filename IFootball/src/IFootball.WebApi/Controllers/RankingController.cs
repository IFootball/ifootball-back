using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFootball.WebApi.Controllers
{
    [ApiController]
    [Route("api/rankings")]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService _rankingService;

        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        [Authorize]
        [Route("player-general")]
        public async Task<ActionResult<IEnumerable<RankingPlayerDto>>> List()
        {
            var response = await _rankingService.ListPlayerGeneral();
            return Ok(response);
        }

    }
}
