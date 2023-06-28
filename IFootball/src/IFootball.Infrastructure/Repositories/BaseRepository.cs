using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace IFootball.Infrastructure.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration _config;
        public BaseRepository(IConfiguration config) 
        { 
            _config = config;
        }

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
