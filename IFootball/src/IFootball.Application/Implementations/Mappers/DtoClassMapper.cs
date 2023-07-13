using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers
{
    public static class DtoClassMapper
    {
        public static ClassDto ToClassDto(this Class newClass)
        {
            return new ClassDto
            {
                Id = newClass.Id,
                Name = newClass.Name
            };
        }
    }
}
