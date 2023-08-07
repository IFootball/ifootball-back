using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Application.Contracts.Documents.Dtos.TeamClass;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Services;
using IFootball.Core;
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
        public async Task<ActionResult<PagedResponse<RankingPlayerDto>>> List()
        {
            var response = await _rankingService.ListPlayerGeneral();
            return Ok(response);
        }

    }
}
