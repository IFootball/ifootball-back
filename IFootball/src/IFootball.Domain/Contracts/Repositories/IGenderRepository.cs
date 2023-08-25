using IFootball.Domain.Models;
using IFootball.Domain.Models.enums;

namespace IFootball.Domain.Contracts.Repositories;

public interface IGenderRepository
{
    Task<bool> ExistsGenderById(long idGender);
    Task<Gender?> FindById(long idGender);
    Task<Gender?> FindByName(GenderName name);
}