using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Core;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class GetScoreUserMapper
{
    public static ScoreUserLogedDto ToScoreUserDto(this User user, long idGenderOne, long idGenderTwo)
    {
        return new ScoreUserLogedDto()
        {
            Name = user.Name,
            ScoreMale = user.GetScore(idGenderOne),
            ScoreFemale = user.GetScore(idGenderTwo)
        };
    }
}