using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IFootball.Application.Contracts.Services
{
    public interface IRankingService
    {
        Task<PagedResponse<RankingPlayerDto>> ListPlayerGeneral(long idGender, Pageable pageable);
        Task<PagedResponse<RankingPlayerDto>> ListGoalScore(int idGender, Pageable pageable);
    }
}
