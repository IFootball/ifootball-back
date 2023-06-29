using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Domain.Models;


namespace IFootball.Application.Implementations.Mappers
{
    public static class LoginUserMapper
    {
        public static LoginUserDto ToLoginUserDto (this User user)
        {
            return new LoginUserDto
            {
                Id = user.Id,
                Role = user.Role,
            };
        }
    }
}
