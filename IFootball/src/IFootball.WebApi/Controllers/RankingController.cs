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
        [Route("player-general/{idGender}")]
        public async Task<ActionResult<PagedResponse<RankingPlayerDto>>> List(
            [FromRoute] int idGender,
            [FromQuery] Pageable pageable)
        {
            var response = await _rankingService.ListPlayerGeneral(idGender, pageable);
            return Ok(response);
        }

    }
}
