using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterClassMapper
{
    public static Class ToClass(this RegisterClassRequest request)
    {
        return new Class(request.Name);

    }
}