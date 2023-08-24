using IFootball.Domain.Models.enums;

namespace IFootball.Application.Contracts.Documents.Dtos
{
    public class LoginUserDto
    {
        public long Id { get; set; }
        public UserRole Role { get; set; }

        public string Name { get; set; }
    }
}
