using IFootball.Domain.Models.enums;
namespace IFootball.Domain.Models
{
    public class User : BaseEntity
    {
        public long IdClass { get; set; }
        public Class Class { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserRole Role = UserRole.User;

        public List<TeamUser> UserTeamsUser { get; set; } = new List<TeamUser>();
        
        public User() { }
        public User(string name, string email, long idClass) 
        {
            Name = name;
            Email = email;
            IdClass = idClass;
        }
        public User(string name, string email, string password, long idClass) 
        {
            Name = name;
            Email = email;
            Password = password;
            IdClass = idClass;
        }
        public void Edit(long idClass, string name, string email) 
        {
            Name = name;
            Email = email;
            IdClass = idClass;
        }
    }
}
