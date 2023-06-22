using IFootball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Domain.Contracts.Repositories
{
    public interface IClassRepository
    {
        Task CreateClassAsync(Class newClass);
        Task<bool> ClassExists(string name);
    }
}
