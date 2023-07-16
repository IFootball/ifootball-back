using System.Net;

namespace IFootball.Domain.Models
{
    public class Class : BaseEntity
    {
        public string? Name { get; set; }
        public List<User>? ClassUsers { get; set; }
        public List<TeamClass>? TeamClasses { get; set; }

        public Class() { }
        public Class(string name) 
        {
            Name = name;
        }
    }
}
