using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories
{
    public interface IClassRepository
    {
        Task CreateClassAsync(Class newClass);
        Task<IEnumerable<Class>> GetAllAsync();
        Task<bool> ClassExistsByName(string name);
        Task<bool> ClassExistsById(long id);
    }
}
