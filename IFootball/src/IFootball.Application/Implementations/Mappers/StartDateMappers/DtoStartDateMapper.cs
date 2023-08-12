using IFootball.Application.Contracts.Documents.Dtos.StartDate;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.StartDateMappers;

public static class DtoStartDateMapper
{
    public static StartDateDto ToStartDateDto(this StartDate startDate)
    {
        return new StartDateDto
        {
            StartDateOfMatches = startDate.StartDateOfMatches
        };
    }
}