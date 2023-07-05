namespace IFootball.Domain.Models;

public class TeamUser : BaseEntity
{
    public User User { get; set; }
    public long IdUser { get; set; }
    
    public Gender Gender { get; set; }
    public long IdGender { get; set; }

    public long IdCoach { get; set; }
    
    public Goalkeeper Goalkeeper { get; set; }
    public long IdGoalkeeper { get; set; }
    
    public long IdLinePlayerFrontLeft { get; set; }
    public LinePlayer LinePlayerFrontLeft { get; set; }

    public long IdLinePlayerFrontRight { get; set; }
    public LinePlayer LinePlayerFrontRight { get; set; }

    public long IdLinePlayerBackRight { get; set; }
    public LinePlayer LinePlayerBackRight { get; set; }

    public long IdLinePlayerBackLeft { get; set; }
    public LinePlayer LinePlayerBackLeft { get; set; }

    public TeamUser() { }
}