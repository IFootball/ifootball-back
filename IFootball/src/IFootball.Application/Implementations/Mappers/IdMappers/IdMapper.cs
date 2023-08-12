using IFootball.Application.Contracts.Documents.Responses;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers.IdMappers;

public static class IdMapper
{
    public static IdResponse ToIdResponse(this long id)
    {
        return new IdResponse
        {
            Id = id
        };
    }
}