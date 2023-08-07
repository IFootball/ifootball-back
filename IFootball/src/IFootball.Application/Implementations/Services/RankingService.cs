using System.Collections;
using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Application.Contracts.Services;
using IFootball.Application.Implementations.Mappers.RankingMappers;
using IFootball.Core;
using IFootball.Domain.Contracts.Repositories;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Services
{
    public class RankingService : IRankingService
    {
        private readonly IRankingRepository _rankingRepository;
        private const int GOAL_SCORE = 8;
        private const int ASSIST_SCORE = 5;
        private const int GOAL_BALANCE = 8;
        private const int GOAL_DEFENSE = 2;
        private const int FAULT = -1;
        private const int YELLOW_CARD = -2;
        private const int RED_CARD = -4;
        private const int PENALT_DEFENSE = 8;
        private const int WIN = 1;

        
        public RankingService(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        public async Task<PagedResponse<RankingPlayerDto>> ListPlayerGeneral()
        {
            var players = await _rankingRepository.ListPlayerGeneral();
            return players.Map(x => x.ToRankingPlayerDto());
        }
        
    }
}


