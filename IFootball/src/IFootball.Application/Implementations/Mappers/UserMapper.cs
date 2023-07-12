    using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers
{
    public static class UserMapper
    {
        public static UserDto toUserDto(this User user) 
        {
            return new UserDto 
            {
                Name = user.Name,
                Email = user.Email,
                IdClass = user.IdClass,
            };
        }
    }
}
