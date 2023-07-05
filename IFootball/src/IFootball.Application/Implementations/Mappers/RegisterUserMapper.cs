using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers;

public static class RegisterUserMapper
{
    public static User toUser(this RegisterUserRequest request)
    {
        return new User(
            request.Name,
            request.Email,
            request.Password,
            request.IdClass
        );
    }
}