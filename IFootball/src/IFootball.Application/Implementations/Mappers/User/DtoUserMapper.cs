    using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers
{
    public static class DtoUserMapper
    {
        public static UserDto DtoToUserDto(this User user) 
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
