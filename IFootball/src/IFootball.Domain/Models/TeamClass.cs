namespace IFootball.Domain.Models;

public class TeamClass : BaseEntity
{
    public Gender Gender { get; set; }
    public Guid IdGender { get; set; }

    
    public List<Goalkeeper> TeamClassGoalkeepers { get; set; }
    public Coach TeamClassCoach { get; set; }
    public List<LinePlayer> TeamClassLinePlayers { get; set; }

    public TeamClass() { }
}