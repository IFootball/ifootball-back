using IFootball.Application.Contracts.Documents.Dtos.StartDate;
using IFootball.Application.Contracts.Documents.Requests.StartDate;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.StartDateMappers;

public static class RegisterStartDateMapper
{
    public static StartDate ToStartDate(this EditStartDateRequest request)
    {
        return new StartDate(request.StartDateOfMatches);
    }
}