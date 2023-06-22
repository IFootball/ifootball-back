using IFootball.Application.Contracts.Documents.Dtos;
using IFootball.Application.Contracts.Documents.Requests;
using IFootball.Domain.Models;

namespace IFootball.Application.Implementations.Mappers
{
    public static class ClassMapper
    {
        public static Class toClass(this RegisterClassRequest request)
        {
            return new Class(request.Name);

        }

        public static ClassDto toClassDto(this Class newClass)
        {
            return new ClassDto
            {
                Id = newClass.Id,
                Name = newClass.Name
            };
        }
    }
}
