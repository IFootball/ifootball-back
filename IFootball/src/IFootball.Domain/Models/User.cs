using IFootball.Domain.Models.enums;

namespace IFootball.Domain.Models
{
    public class User
    {
        public User() { }

        public Guid Id { get; set; }
        public Guid IdClass { get; set; }
        public Class Class { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
