using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFootball.Application.Contracts.Documents.Dtos.Ranking;
using IFootball.Core;

namespace IFootball.Application.Contracts.Services
{
    public interface IRankingService
    {
        Task<PagedResponse<RankingPlayerDto>> ListPlayerGeneral();
    }
}
