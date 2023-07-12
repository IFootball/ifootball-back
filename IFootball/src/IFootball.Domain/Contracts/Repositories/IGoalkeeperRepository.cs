using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories
{
    public interface IGoalkeeperRepository
    {
        Task<IList<Goalkeeper>> ListGoalkeeperAsync(long id, int pageNumber, int pageSize);
    }
}
