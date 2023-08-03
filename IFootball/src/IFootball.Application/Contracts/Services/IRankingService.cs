using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Services
{
    public interface IRankingService
    {
        Task<IEnumerable<RankingPlayerDto>> ListPlayerGeneral();
    }
}
