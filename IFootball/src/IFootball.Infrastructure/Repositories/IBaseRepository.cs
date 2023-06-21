using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Infrastructure.Repositories
{
    public interface IBaseRepository
    {
        public SqliteConnection GetConnection();
    }
}
