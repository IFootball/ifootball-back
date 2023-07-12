using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories
{
    public interface ILinePlayerRepository
    {
        Task<IList<LinePlayer>> ListLinelayersAsync(long id, int pageNumber, int pageSize);
    }
}
