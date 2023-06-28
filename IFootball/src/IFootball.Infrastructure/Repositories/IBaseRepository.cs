using Microsoft.Data.Sqlite;

namespace IFootball.Infrastructure.Repositories
{
    public interface IBaseRepository
    {
        public SqliteConnection GetConnection();
    }
}
