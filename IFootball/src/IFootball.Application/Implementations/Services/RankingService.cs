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

        public RankingService(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        public async Task<PagedResponse<RankingPlayerDto>> ListPlayerGeneral(long idGender, Pageable pageable)
        {
            var players = await _rankingRepository.ListPlayerGeneral(idGender, pageable);
            return players.Map(player => player.ToRankingPlayerDto());
        }
        
        public async Task<PagedResponse<RankingTeamClassDto>> ListTeamClassScore(int idGender, Pageable pageable)
        {
            var teamClass = await _rankingRepository.ListTeamClassScore(idGender, pageable);
            return teamClass.Map(teamClass => teamClass.ToRankingTeamClassDto());           
        }

        public async Task<PagedResponse<RankingUserDto>> ListUserScore(int idGender, Pageable pageable)
        {
            var user = await _rankingRepository.ListUserScore(idGender, pageable);
            return user.Map(user => user.ToRankingUserDto());           
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



 
    }
}


