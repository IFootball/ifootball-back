using System.Net;

namespace IFootball.Domain.Models
{
    public class Class : BaseEntity
    {
        public Class() { }
        
        public string Name { get; set; }
        public List<User> ClassUsers { get; set; }
        public List<Goalkeeper> ClassGoalkeepers { get; set; }
        public List<Coach> ClassCoches { get; set; }
        public List<LinePlayer> ClassLinePlayer { get; set; }

    }
}
