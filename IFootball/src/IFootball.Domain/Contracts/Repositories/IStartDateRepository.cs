using IFootball.Domain.Models;

namespace IFootball.Domain.Contracts.Repositories;

public interface IStartDateRepository
{
    Task Edit(StartDate startDate);
    Task<StartDate?> FindStarDate();
    Task Register(StartDate startDate);
}