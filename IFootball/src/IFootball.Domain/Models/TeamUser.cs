namespace IFootball.Domain.Models;

public class TeamUser : BaseEntity
{
    public User User { get; set; }
    public Guid IdUser { get; set; }
    
    public Gender Gender { get; set; }
    public Guid IdGender { get; set; }

    public Coach Coach { get; set; }
    public Guid IdCoach { get; set; }
    
    public Goalkeeper Goalkeeper { get; set; }
    public Guid IdGoalkeeper { get; set; }
    
    public Guid IdLinePlayerFrontLeft { get; set; }
    public LinePlayer LinePlayerFrontLeft { get; set; }

    public Guid IdLinePlayerFrontRight { get; set; }
    public LinePlayer LinePlayerFrontRight { get; set; }

    public Guid IdLinePlayerBackRight { get; set; }
    public LinePlayer LinePlayerBackRight { get; set; }

    public Guid IdLinePlayerBackLeft { get; set; }
    public LinePlayer LinePlayerBackLeft { get; set; }

    public TeamUser() { }
}