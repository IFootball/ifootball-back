using IFootball.Domain.Models.enums;

namespace IFootball.Domain.Models;

public class Gender : BaseEntity
{
    public GenderName Name { get; set; }
    
    public List<Player>? GenderPlayers { get; set; } = new List<Player>();
    public List<TeamClass>? GenderTeamClasses { get; set; } = new List<TeamClass>();
    public List<TeamUser>? GenderTeamUsers { get; set; } = new List<TeamUser>();

    public Gender() { }
}