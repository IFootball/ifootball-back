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

        public async Task<PagedResponse<RankingPlayerDto>> ListPlayerGeneral(long idGender, Pageable pageable)
        {
            var players = await _rankingRepository.ListPlayerGeneral(idGender, pageable);
            return players.Map(player => player.ToRankingPlayerDto(GetScorePlayer(player)));
        }

        public async Task<PagedResponse<RankingPlayerDto>> ListGoalScore(int idGender, Pageable pageable)
        {
            var players = await _rankingRepository.ListGoalScore(idGender, pageable);
            return players.Map(player => player.ToRankingPlayerDto(player.Goals));
        }

        public async Task<PagedResponse<RankingPlayerDto>> ListAssistScore(int idGender, Pageable pageable)
        {
            var players = await _rankingRepository.ListAssistScore(idGender, pageable);
            return players.Map(player => player.ToRankingPlayerDto(player.Assists));        
        }

        public async Task<PagedResponse<RankingPlayerDto>> ListDefenseScore(int idGender, Pageable pageable)
        {
            var players = await _rankingRepository.ListDefenseScore(idGender, pageable);
            return players.Map(player => player.ToRankingPlayerDto(player.Goalkeeper.Saves));         
        }

        private int GetScorePlayer(Player player)
        {
            return ((player.Assists * ASSIST_SCORE) + (player.Goals * GOAL_SCORE) + (player.YellowCard * YELLOW_CARD) 
                    + (player.RedCard * RED_CARD) + (player.Fouls * FAULT) + (player.Wins * WIN));
        }

    }
}


