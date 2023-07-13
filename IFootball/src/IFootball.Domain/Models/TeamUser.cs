namespace IFootball.Domain.Models;

public class TeamUser : BaseEntity
{
    public User User { get; private set; }
    public long IdUser { get; private set; }
    
    public Gender Gender { get; private set; }
    public long IdGender { get; private set; }
    
    public Goalkeeper Goalkeeper { get; private set; }
    public long IdGoalkeeper { get; private set; }
    
    public long IdLinePlayerFrontLeft { get; private set; }
    public LinePlayer LinePlayerFrontLeft { get; private set; }

    public long IdLinePlayerFrontRight { get; private set; }
    public LinePlayer LinePlayerFrontRight { get; private set; }

    public long IdLinePlayerBackRight { get; private set; }
    public LinePlayer LinePlayerBackRight { get; private set; }

    public long IdLinePlayerBackLeft { get; private set; }
    public LinePlayer LinePlayerBackLeft { get; private set; }

    public TeamUser() { }

    public void AddUser(long idUser)
    {
        IdUser = idUser;
    }

    public TeamUser(long idGender,  long idGoalkeeper, long idLinePlayerFrontLeft, long idLinePlayerFrontRight, long idLinePlayerBackRight, long idLinePlayerBackLeft)
    {
        IdGender = idGender;
        IdGoalkeeper = idGoalkeeper;
        IdLinePlayerFrontLeft = idLinePlayerFrontLeft;
        IdLinePlayerFrontRight = idLinePlayerFrontRight;
        IdLinePlayerBackRight = idLinePlayerBackRight;
        IdLinePlayerBackLeft = idLinePlayerBackLeft;
    }
}