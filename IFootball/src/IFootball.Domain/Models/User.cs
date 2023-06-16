using IFootball.Domain.Models.enums;

namespace IFootball.Domain.Models
{
    public class User : BaseEntity
    {
        public Guid IdClass { get; set; }
        public Class Class { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserRole Role = UserRole.User;

        public TeamUser UserTeamUser { get; set; }
        
        public User() { }
        public User(string name, string email, string password, Guid idClass) 
        {
            Name = name;
            Email = email;
            Password = password;
            IdClass = idClass;
        }
    }
}
