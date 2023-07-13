namespace IFootball.Domain.Contracts.Repositories;

public interface IGenderRepository
{
    Task<bool> ExistsGenderById(long idGender);
}