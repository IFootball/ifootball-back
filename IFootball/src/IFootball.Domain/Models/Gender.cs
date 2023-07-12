using IFootball.Domain.Models.enums;

namespace IFootball.Domain.Models;

public class Gender : BaseEntity
{
    public GenderName Name { get; set; }
    
    public List<Goalkeeper> GenderGoalkeepers { get; set; }
    public List<LinePlayer> GenderLinePlayers { get; set; }
    public List<TeamClass> GenderTeamClasses { get; set; }
    public List<TeamUser> GenderTeamUsers { get; set; }

    public Gender() { }
}